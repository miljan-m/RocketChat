import Avatar from '@mui/material/Avatar'
import React from 'react'
import '../Styles/Message.css'

const Message = ({ message }) => {
    return (
        <div className="message-wrapper">
            <Avatar />
            <div className="message-text">
                {
                    message.message
                }

                {
                    (new Date().toLocaleTimeString())
                }

            </div>
        </div>
    )
}

export default Message