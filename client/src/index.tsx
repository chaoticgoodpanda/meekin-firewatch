import React from 'react';
import ReactDOM from 'react-dom';
import './app/layout/styles.css';
import reportWebVitals from './reportWebVitals';
import App from "./app/layout/App";
import {Router} from "react-router-dom";
import {createBrowserHistory} from "history";
import {configureStore} from "./app/store/configureStore";
import {Provider} from "react-redux";

const store = configureStore();

export const history = createBrowserHistory();

ReactDOM.render(
  <React.StrictMode>
      <Provider store={store}>
          <Router history={history}>
              <App />
          </Router>
      </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
