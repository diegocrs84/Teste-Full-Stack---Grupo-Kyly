import React, { useState } from 'react';
import { authService } from '../services/api';
import '../styles/Login.css';

export default function Login({ onLoginSuccess }) {
  const [username, setUsername] = useState('demo');
  const [password, setPassword] = useState('demo123');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setLoading(true);

    const result = await authService.login(username, password);

    if (result.success) {
      onLoginSuccess();
    } else {
      setError(result.message || 'Falha na autenticação');
    }

    setLoading(false);
  };

  return (
    <div className="login-container">
      <div className="login-card">
        <h1>Kyly Products</h1>
        <p className="subtitle">Sistema de Busca de Produtos</p>

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="username">Usuário</label>
            <input
              type="text"
              id="username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              placeholder="Usuário padrão: demo"
              disabled={loading}
            />
          </div>

          <div className="form-group">
            <label htmlFor="password">Senha</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Senha padrão: demo123"
              disabled={loading}
            />
          </div>

          {error && <div className="error-message">{error}</div>}

          <button 
            type="submit" 
            className="login-button"
            disabled={loading}
          >
            {loading ? 'Autenticando...' : 'Entrar'}
          </button>
        </form>

        <div className="demo-info">
          <h3>Credenciais de Demonstração:</h3>
          <p><strong>Usuário:</strong> demo</p>
          <p><strong>Senha:</strong> demo123</p>
        </div>
      </div>
    </div>
  );
}
