import { useToken } from './auth'

const backend = 'http://localhost:5000/api/user'

const { token, setToken } = useToken()

export async function login (Email, password) {
    const response = await request(`/login`, {
        method: 'POST',
        body: JSON.stringify({ Email, password }),
    })

    if (response.token) {
        setToken(response.token)
    }

    return response.token
}

export async function register (Email, password, username) {
    const response = await request(`/register`, {
        method: 'POST',
        body: JSON.stringify({ Email, password, username }),
    })

    return response;
}

// Die Funktion welche requests macht
async function request (url, options) {
    const headers = {
        'Content-Type': 'application/json',
        'X-Requested-With': 'XMLHttpRequest',
    }

    if (token.value) {
        headers['Authorization'] = 'Bearer ' + token.value
    }

    const response = await fetch(backend + url, { headers, ...options })

    if (response.ok) {
        return response.json()
    } else if (response.status === 422) {
        const data = await response.json()

        throw new ValidationError('validation failed', data.errors)
    } else {
        throw new Error(`Server error: ${await response.text()}`)
    }
}


class ValidationError {
    message
    errors

    constructor (message, errors) {
        this.message = message
        this.errors = errors
    }
}