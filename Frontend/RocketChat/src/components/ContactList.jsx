import React from 'react'
import '../Styles/ContactList.css'
import Avatar from '@mui/material/Avatar'
import ControlPointIcon from '@mui/icons-material/ControlPoint';

const ContactList = () => {
    var contacts = [{ username: 'miljanm', lastMessage: 'ovo je zadnja poruka' },
    { username: 'mirko997', lastMessage: 'ovo je mirkova' }]



    return (
        <div className="contact-list-main-wrapper">
            <div className="contact-list-wrapper">
                {
                    contacts.map(c => (
                        <div className='receiver-div'>
                            <Avatar>{c.username.charAt(0)}</Avatar>
                            <div className='username-message-div'>
                                <span>{c.username}</span>
                                <span>{c.lastMessage.slice(0, 20)}...</span>
                            </div>
                        </div>
                    ))
                }
            </div>
            <button><ControlPointIcon color='primary' /></button>
        </div>

    )
}

export default ContactList