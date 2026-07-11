import React from 'react'
import { Route, Routes } from 'react-router-dom'
import SignUp from './Pages/SignUp'
import SignIn from './Pages/SignIn'
import HomePage from './Pages/HomePage'

const app = () => {
    return (
        <Routes>
            <Route path='' element={<SignIn />} />
            <Route path='/signup' element={<SignUp />} />
            <Route path='/signin' element={<SignIn />} />
            <Route path='/home' element={<HomePage />} />
        </Routes>
    )
}

export default app