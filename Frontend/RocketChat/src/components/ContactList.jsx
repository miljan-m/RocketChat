import React, { useContext, useEffect, useState } from 'react'
import '../Styles/ContactList.css'
import Avatar from '@mui/material/Avatar'
import ControlPointIcon from '@mui/icons-material/ControlPoint';
import '../Styles/Popup.css'
import axios from 'axios'
import { LoginContext } from '../Context/LoginContext';

const ContactList = ({ setReceiverUp }) => {
    const [isOpen, setIsOpen] = useState(false)
    const [receiverUsername, setReceiverUsername] = useState()
    const [receivers, setReceivers] = useState([])
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    const { user } = useContext(LoginContext)
    const logedUser = user;

    const openClosePopup = () => {
        setIsOpen(!isOpen)
    }

    useEffect(() => {
        const fetchReceivers = async () => {
            const messages = await axios.get(`${baseUrl}/message`)

            // uzmi samo poruke u kojima ulogovani korisnik učestvuje (kao sender ili receiver)
            const myMessages = messages.data.filter(message =>
                message?.senderUsername === logedUser?.userName ||
                message?.receiverUsername === logedUser?.userName
            )

            // za svaku poruku izvuci "drugu stranu" (onog ko nije ulogovani korisnik)
            const otherUsernames = myMessages.map(message =>
                message.senderUsername === logedUser.userName
                    ? message.receiverUsername
                    : message.senderUsername
            )

            const uniqueUsernames = Array.from(new Set(otherUsernames))

            const users = await axios.get(`${baseUrl}/user`)
            const filteredUsers = users.data.filter(user =>
                uniqueUsernames.includes(user.userName)
            )
            setReceivers(filteredUsers)
        }
        fetchReceivers()
    }, [])

    const addConversation = async (username) => {
        try {
            var result = await axios.get(`${baseUrl}/user/username/${username}`)
            setReceivers([...receivers, result.data])
            setReceiverUp(result.data)
            setIsOpen(!isOpen)
        } catch (error) {
            console.log(error);
        }
    }
    return (
        <div className="contact-list-main-wrapper">
            <div className="contact-list-wrapper">
                {
                    receivers.length > 0 && receivers.map(receiver => (receiver.userName != logedUser.userName &&
                        <div className='receiver-div' onClick={() => setReceiverUp(receiver)}>
                            <Avatar>{receiver?.userName.charAt(0)}</Avatar>
                            <div className='username-message-div'>
                                <span>{receiver?.userName}</span>
                            </div>
                        </div>
                    ))
                }
            </div>
            <button onClick={() => openClosePopup()}><ControlPointIcon color='primary' /></button>
            {isOpen ? (<div
                className="new-chat-overlay"
                onClick={(e) => e.target === e.currentTarget && closePopup()}
            >
                <div className="new-chat-popup">
                    <input
                        type="text"
                        onChange={(e) => setReceiverUsername(e.target.value)}
                        placeholder="Username"
                    />

                    <div className="new-chat-popup-buttons">
                        <button className="btn-cancel" onClick={openClosePopup}>
                            Close
                        </button>
                        <button className="btn-confirm" onClick={() => addConversation(receiverUsername)}>
                            Add
                        </button>
                    </div>
                </div>
            </div>
            ) : null}
        </div>

    )
}

export default ContactList