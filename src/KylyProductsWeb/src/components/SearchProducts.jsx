import React, { useState, useEffect } from 'react';
import { productService, authService } from '../services/api';
import '../styles/SearchProducts.css';

export default function SearchProducts({ onLogout }) {
  const [keyword, setKeyword] = useState('');
  const [results, setResults] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    if (keyword.length > 0) {
      handleSearch(1);
    } else {
      setResults(null);
    }
  }, [keyword]);

  const handleSearch = async (page = 1) => {
    if (!keyword.trim()) {
      setError('Digite uma palavra-chave para buscar');
      return;
    }

    setLoading(true);
    setError('');

    try {
      const data = await productService.searchProducts(keyword, page);
      setResults(data);
      setCurrentPage(page);
    } catch (err) {
      setError('Erro ao buscar produtos. Tente novamente.');
      console.error('Erro:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleLogout = () => {
    authService.logout();
    onLogout();
  };

  const handlePreviousPage = () => {
    if (results && currentPage > 1) {
      handleSearch(currentPage - 1);
    }
  };

  const handleNextPage = () => {
    if (results && currentPage < results.totalPages) {
      handleSearch(currentPage + 1);
    }
  };

  return (
    <div className="search-container">
      <div className="header">
        <div className="header-content">
          <h1>🏢 Kyly Products</h1>
          <button className="logout-button" onClick={handleLogout}>
            Sair
          </button>
        </div>
      </div>

      <div className="search-section">
        <div className="search-box">
          <input
            type="text"
            placeholder="Busque por código, descrição, cor ou tamanho..."
            value={keyword}
            onChange={(e) => setKeyword(e.target.value)}
            className="search-input"
            disabled={loading}
          />
          <button 
            className="search-button"
            onClick={() => handleSearch(1)}
            disabled={loading || !keyword.trim()}
          >
            {loading ? '⏳ Buscando...' : '🔍 Buscar'}
          </button>
        </div>

        {error && <div className="error-message">{error}</div>}
      </div>

      {results && (
        <div className="results-section">
          <div className="results-info">
            <h2>Resultados</h2>
            <p className="results-stats">
              Total: <strong>{results.totalCount}</strong> produtos encontrados
            </p>
          </div>

          {results.items.length === 0 ? (
            <div className="no-results">
              <p>Nenhum produto encontrado para "{keyword}"</p>
            </div>
          ) : (
            <>
              <div className="products-grid">
                {results.items.map((product) => (
                  <div key={product.id} className="product-card">
                    <div className="product-header">
                      <h3>{product.productCode}</h3>
                      {product.relevancePriority === 1 && (
                        <span className="badge badge-priority-1">⭐ Lista 1</span>
                      )}
                      {product.relevancePriority === 2 && (
                        <span className="badge badge-priority-2">⭐ Lista 2</span>
                      )}
                    </div>

                    <div className="product-details">
                      <p>
                        <strong>Descrição:</strong> {product.productDescription}
                      </p>
                      <p>
                        <strong>Cor:</strong> {product.colorDescription}
                      </p>
                      <p>
                        <strong>Tamanho:</strong> {product.sizeDescription}
                      </p>
                      <p className="product-id">
                        <small>ID: {product.id}</small>
                      </p>
                    </div>
                  </div>
                ))}
              </div>

              {results.totalPages > 1 && (
                <div className="pagination">
                  <button
                    className="pagination-button"
                    onClick={handlePreviousPage}
                    disabled={currentPage === 1}
                  >
                    ← Anterior
                  </button>

                  <div className="page-info">
                    Página <strong>{results.currentPage}</strong> de{' '}
                    <strong>{results.totalPages}</strong>
                  </div>

                  <button
                    className="pagination-button"
                    onClick={handleNextPage}
                    disabled={currentPage >= results.totalPages}
                  >
                    Próxima →
                  </button>
                </div>
              )}
            </>
          )}
        </div>
      )}
    </div>
  );
}
