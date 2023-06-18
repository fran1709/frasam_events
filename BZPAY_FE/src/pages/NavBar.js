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
                            Eventos
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ruta1">Opcion 1</Dropdown.Item>
                            <Dropdown.Item href="/ruta2">Opcion 2</Dropdown.Item>
                            <Dropdown.Item href="/ruta3">Opcion 3</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
                <li className="navbar-item">
                    <Dropdown>
                        <Dropdown.Toggle variant="link" id="escenarios-dropdown">
                            Escenarios
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ruta4">Opcion 1</Dropdown.Item>
                            <Dropdown.Item href="/ruta5">Opcion 2</Dropdown.Item>
                            <Dropdown.Item href="/ruta6">Opcion 3</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
                <li className="navbar-item">
                    <Dropdown>
                        <Dropdown.Toggle variant="link" id="asientos-dropdown">
                            Asientos
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item href="/ruta7">Opcion 1</Dropdown.Item>
                            <Dropdown.Item href="/ruta8">Opcion 2</Dropdown.Item>
                            <Dropdown.Item href="/ruta9">Opcion 3</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </li>
            </ul>
        </nav>
    );

}

export default Navbar;
