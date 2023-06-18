import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import Cookies from 'universal-cookie';
import '../css/Navbar.css'; // Importa el archivo CSS para estilos específicos de la barra de navegación
import { Dropdown } from 'react-bootstrap';

function Navbar() {
    const navigate = useNavigate();
    const cookies = new Cookies();
    const cerrarSesion = () => {
        cookies.remove('username', { path: '/' });
        navigate('/');
    };

    

    return (
        <nav className="navbar">
            <ul className="navbar-list">
                <li className="navbar-item">
                    <Dropdown>
                        <Dropdown.Toggle variant="link" id="eventos-dropdown">
                            Admin
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ListarEventos">Listar Eventos</Dropdown.Item>
                            <Dropdown.Item href="/ruta2">Detalle de Eventos</Dropdown.Item>
                            <Dropdown.Item href="/ruta3">Crear Entradas</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
                <li className="navbar-item">
                    <Dropdown>
                        <Dropdown.Toggle variant="link" id="escenarios-dropdown">
                            Cliente
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ListarEventos">Listar Eventos</Dropdown.Item>
                            <Dropdown.Item href="/ruta5">Detalle de Entradas</Dropdown.Item>
                            <Dropdown.Item href="/ruta6">Reserva de Entradas</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
                <li className="navbar-item">
                    <Dropdown>
                        <Dropdown.Toggle variant="link" id="asientos-dropdown">
                            Cajero
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ruta7">Detalles del Cliente</Dropdown.Item>
                            <Dropdown.Item href="/ruta8">Reservas del Cliente</Dropdown.Item>
                            <Dropdown.Item href="/ruta9">Imprimir Entradas en PDF</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
            </ul>
        </nav>
    );

}

export default Navbar;
