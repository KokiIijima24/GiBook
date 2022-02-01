import React, { useState } from 'react'
import { useSelector } from 'react-redux'
import { getCurrentuser } from '../store/auth'

import { baseRepository } from '../api/auth'
import { googleBookAPI } from '../api/api'

import InputField from '../components/Utils/InputForm'

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
    baseRepository.post('gibook/regist', {
      giverId: User.id,
      giver: {
        email: User.email,
      },
    })
  }

  const handleSubmitToGoogleBookAPI = (event) => {
    event.preventDefault()
    googleBookAPI.get('v1/volumes', {
      params: {
        q: 'Angular',
      },
    })
  }

  return (
    <div>
      書籍名の検索
      <form onSubmit={handleSubmitToGoogleBookAPI}>
        <InputField
          label='書籍名'
          type='text'
          name='bookTitle'
          value={bookTitle}
          onChange={handleChange}
        />
        <input type='submit' value='検索' />
      </form>
      <br />
      参加登録
      <form onSubmit={handleSubmit}>
      <InputField
          label='識別番号'
          type='text'
          name='bookTitle'
          value={bookTitle}
          onChange={handleChange}
        />
        <InputField
          label='参加者ニックネーム'
          type='text'
          name='bookTitle'
          value={bookTitle}
          onChange={handleChange}
        />
        <input type='submit' value='登録' />
      </form>
    </div>
  )
}
