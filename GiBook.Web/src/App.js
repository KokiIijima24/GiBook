import React from 'react'
import { BrowserRouter, Switch } from 'react-router-dom'
import { Provider } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'

import store, { persistor } from './store/'
import PrivateRoute from './components/Router/PrivateRoute'
import GuestRoute from './components/Router/GuestRoute'
import AppRoute from './components/Router/AppRoute'

import Home from './Pages/Home'
import Login from './Pages/Login'
import About from './Pages/About'

import LoginLayout from './Layout/LoginLayout'
import MainLayout from './Layout/MainLayout'
import Regist from './Pages/Regist'
import SelectTag from './Pages/SelectTag'
import Meeting from './Pages/Meeting'


function App() {
  return (
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <BrowserRouter>
          <Switch>
            <AppRoute path='/' exact layout={MainLayout} component={Home} />
            <GuestRoute path='/login' layout={LoginLayout} component={Login} />
            <GuestRoute path='/about' layout={MainLayout} component={About} />
            {/* <PrivateRoute path='/about' layout={MainLayout} component={About} /> */}
            <GuestRoute path='/regist' layout={MainLayout} component={Regist} />
            <GuestRoute path='/select-tag' layout={MainLayout} component={SelectTag} />
            <GuestRoute path='/meeting' layout={MainLayout} component={Meeting} />
          </Switch>
        </BrowserRouter>
      </PersistGate>
    </Provider>
  )
}

export default App
