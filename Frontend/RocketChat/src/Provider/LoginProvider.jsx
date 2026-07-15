import React, { useState } from 'react'
import { LoginContext } from '../Context/LoginContext'
import axios from 'axios';
import { useNavigate } from 'react-router-dom'

const LoginProvider = ({ children }) => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    const [user, setUser] = useState()
    const navigate = useNavigate()
    const HandleLogin = async (username, password) => {
        try {
            var getUserRespone = await axios.get(`${baseUrl}/user/username/${username}`)
            setUser(getUserRespone.data);
            console.log(getUserRespone.data)
            var response = await axios.post(`${baseUrl}/login`, { email:username, password:password })
            navigate("/chat")
            localStorage.setItem('accessToken', response.data.accessToken)
        } catch (error) {
            console.log(error)
        }
    }


    return (
        <LoginContext.Provider value={{ user, HandleLogin }}>
            {children}
        </LoginContext.Provider>
    )
}

export default LoginProvider