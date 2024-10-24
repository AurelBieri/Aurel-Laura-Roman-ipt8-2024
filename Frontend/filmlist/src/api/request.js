import { useToken } from "./auth";

const backend = "http://localhost:5000/api";

const { token, setToken } = useToken();

export async function login(Email, password) {
  const response = await request(`/user/login`, {
    method: "POST",
    body: JSON.stringify({ Email, password }),
  });

  if (response.token) {
    setToken(response.token);
  }

  return response.token;
}

export async function register(username, Email, password) {
  const response = await request(`/user/register`, {
    method: "POST",
    body: JSON.stringify({ Email, password, username }),
  });

  return response;
}

//Filmlist Funktionen

//Macht eine Filmliste
export async function makefilmlist(Filmlist) {
  const response = await request(`/movielist`, {
    method: "POST",
    body: JSON.stringify({ Filmlist }),
  });

  return response;
}

//Holt Liste mit einer id
export async function getfilmlistbyid(filmListId) {
  const response = await request(`/movielist/${filmListId}`, {
    method: "Get",
  });

  return response;
}

//Holt Alle Listen
export async function getallfilmlist() {
  const response = await request(`/movielist/all`, {
    method: "Get",
  });

  return response;
}

// Die Funktion welche requests macht
async function request(url, options) {
  const headers = {
    "Content-Type": "application/json",
    "X-Requested-With": "XMLHttpRequest",
  };

  if (token.value) {
    headers["Authorization"] = "Bearer " + token.value;
  }

  const response = await fetch(backend + url, { headers, ...options });

  if (response.ok) {
    return response.json();
  } else if (response.status === 422) {
    const data = await response.json();

    throw new ValidationError("validation failed", data.errors);
  } else {
    throw new Error(`Server error: ${await response.text()}`);
  }
}

class ValidationError {
  message;
  errors;

  constructor(message, errors) {
    this.message = message;
    this.errors = errors;
  }
}
