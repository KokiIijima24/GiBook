import axios from 'axios';

export default axios.create({
  baseURL: `https://localhost:7042/api/`
});

export const googleBookAPI = axios.create({
  baseURL: `https://www.googleapis.com/books/`
})