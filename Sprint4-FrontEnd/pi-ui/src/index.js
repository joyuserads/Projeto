import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './pages/home/App';
import Login from './pages/Login/Login';
import Equipamento from './pages/Equipamentos/equipamento';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import { parseJwt, usuarioAutenticado } from './services/auth';


import { Navigate } from 'react-router-dom';

const PermissaoAdm = ({ children }) => {
  const tokenValido = usuarioAutenticado();
  const role = tokenValido ? parseJwt().role : null;

  if (tokenValido && (role === "1" || role === "2")) {
    return children;
  } else {
    return <Navigate to="/" replace />;
  }
};


const routing = (
  <React.StrictMode>
    <HelmetProvider>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />

          <Route
            path="/app"
            element={
              <PermissaoAdm>
                <App />
              </PermissaoAdm>
            }
          />

          <Route
            path="/equipamento"
            element={
              <PermissaoAdm>
                <Equipamento />
              </PermissaoAdm>
            }
          />

          
        </Routes>

      </Router>

    </HelmetProvider>
  </React.StrictMode>
);

reportWebVitals();

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(routing);





// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
