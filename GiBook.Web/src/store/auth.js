import { createSlice } from '@reduxjs/toolkit'

import API from '../api/api'

const initialState = {
  user: null, // ユーザー情報の格納場所
}

const slice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setUser: (state, action) => {
      return Object.assign({}, state, { user: action.payload })
    },
    signOut: (state) => {
      return Object.assign({}, state, { user: null })
    },
  },
})

export default slice.reducer

// 認証済みか確認するセレクター
export const isAuthSelector = (state) => {
  return state.auth.user !== null
}

export const getCurrentuser = (state) => {
  const userInfo = {
    id: state.auth.user.id,
    displayName: state.auth.user.displayName,
    username: state.auth.user.userName,
    email: state.auth.user.email
  }
  return userInfo
}

// ログイン機能
export function login(username, password) {
  return async function (dispatch) {
    //const user = await loginApi(username, password)
    let body = { email: username, password: password }
    API
      .post('account/login', body)
      .then(async (response) => {
        localStorage.setItem('TOKEN', response.data.token)
        // ログイン後にユーザー情報をストアに格納する
        dispatch(slice.actions.setUser(response.data))
      })
  }
}

// サインアウト
export function logout() {
  return async function (dispatch) {
    dispatch(slice.actions.signOut([]))
  }
}
