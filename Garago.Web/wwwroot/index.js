import React from 'react';
import Provider from './contexts/Provider';
import { Router } from 'react-router';
import { createBrowserHistory } from 'history';
import { render } from 'react-dom';
import App from './screens/App';
import './App.css';


const history = createBrowserHistory();

render(<Router history={history}>
            <Provider history={history}>
                <App />
            </Provider>
        </Router>, document.getElementById('root'));