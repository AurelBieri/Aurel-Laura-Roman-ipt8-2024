import { useToken } from './auth'

const backend = 'http://localhost:5000/api'

const { token, setToken } = useToken()

export async function login (email, password) {
    const response = await request(`/login`, {
        method: 'POST',
        body: JSON.stringify({ email, password }),
    })

    if (response.token) {
        setToken(response.token)
    }

    return response.token
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