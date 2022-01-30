import React, { useState } from 'react'
import { useSelector } from 'react-redux'
import { getCurrentuser } from '../store/auth'

import {baseRepository} from '../api/auth'

export default function Regist() {
  const User = useSelector(getCurrentuser)
  const [bookTitle, setBookTitle] = useState('')

  const handleChange = (event) => {
    switch (event.target.name) {
      case 'bookTitle':
        setBookTitle(event.target.value)
        break
      default:
        console.log('key not found')
    }
  }

  const handleSubmit = (event) => {
    event.preventDefault()
    console.log('user:', User)
    console.log(bookTitle)
    baseRepository.post('gibook/regist', {
      giverId: User.id,
    })
  }

  return (
    <div>
      Regist
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input
            type='text'
            name='bookTitle'
            value={bookTitle}
            onChange={handleChange}
          />
        </label>
        <input type='submit' value='Submit' />
      </form>
    </div>
  )
}
