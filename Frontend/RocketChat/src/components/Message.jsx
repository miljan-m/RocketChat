import Avatar from '@mui/material/Avatar'
import React from 'react'
import '../Styles/Message.css'

const Message = ({ message }) => {
    return (
        <div className="message-wrapper">
            <Avatar style={{ cursor: 'pointer' }} />
            <div className='whole-message'>
                {message.username}
                <div className="message-text">
                    {
                        message.message
                    }

                    {
                        (new Date().toLocaleTimeString())
                    }
                </div>
            </div>
        </div>
    )
}

export default Message