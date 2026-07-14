import React from 'react'
import { Route, Routes } from 'react-router-dom'
import SignUp from './Pages/SignUp'
import SignIn from './Pages/SignIn'
import ChatPage from './Pages/ChatPage'

const app = () => {
    return (
        <Routes>
            <Route path='' element={<SignIn />} />
            <Route path='/signup' element={<SignUp />} />
            <Route path='/signin' element={<SignIn />} />
            <Route path='/chat' element={<ChatPage />} />
        </Routes>
    )
}

export default app