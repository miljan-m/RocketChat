import React from 'react'
import '../Styles/ReceiverDiv.css'
import Avatar from '@mui/material/Avatar'

const ReceiverDiv = () => {

    var contacts = { fullName: 'Miljan Mitic', lastMessage: 'ovo je zadnja poruka' }

    return (
        <div className="receiver-div-wrapper">
            <span>{contacts.fullName}</span>
            <Avatar style={{cursor:'pointer'}}>{contacts.fullName.charAt(0)}</Avatar>
        </div>
    )
}

export default ReceiverDiv