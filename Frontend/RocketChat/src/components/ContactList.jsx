import React, { useEffect, useState } from 'react'
import '../Styles/ContactList.css'
import Avatar from '@mui/material/Avatar'
import ControlPointIcon from '@mui/icons-material/ControlPoint';
import '../Styles/Popup.css'
import axios from 'axios'

const ContactList = ({ setReceiverUp }) => {
    const [isOpen, setIsOpen] = useState(false)
    const [receiverUsername, setReceiverUsername] = useState()
    const [receiver, setReceiver] = useState([])
    const [currentReceiver, setCurrentReceiver] = useState()
    const baseUrl = import.meta.env.VITE_API_BASE_URL;

    const openClosePopup = () => {
        setIsOpen(!isOpen)
    }

    useEffect(() => {
        const fetchReceivers = async () => {
            const messages = await axios.get(`${baseUrl}/message`)//izvlacim sve poruke
            const uniqueReceiverMessages = Array.from(
                new Map(messages.data.map(message => [message.receiverUsername, message])).values()
            )//filtriram poruke sa unique username
            const users = await axios.get(`${baseUrl}/user`)//izvlacim sve korisnike
            const filteredUsers = users.data.filter(user =>
                uniqueReceiverMessages.some(message =>
                    message.receiverUsername === user.userName
                )
            )
            setReceiver(filteredUsers)
        }
        fetchReceivers()
    }, [])

    const addConversation = async (username) => {
        try {
            var result = await axios.get(`${baseUrl}/user/username/${username}`)
            setReceiver([...receiver, result.data])
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
                    receiver.length > 0 && receiver.map(receiver => (
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