import React, { useEffect, useState } from 'react';
import Navbar from './NavBar';

function ListarEventos() {
    const [eventos, setEventos] = useState([]);

    useEffect(() => {
        obtenerEventos();
    }, []);

    const obtenerEventos = async () => {
        const url = 'https://localhost:7052/api/Evento/GetAllEventos'; // Cambia la URL según tu API
        const origin = 'https://localhost:3000';

        const myHeaders = {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': origin
        };

        const settings = {
            method: 'get',
            headers: myHeaders
        };

        try {
            const response = await fetch(url, settings);
            const data = await response.json();
            console.log(data);

            if (!response.ok) {
                const message = `Un error ha ocurrido: ${response.status}`;
                throw new Error(message);
            }

            setEventos(data);
        } catch (error) {
            console.log(error);
        }
    };

    const verDetalles = () => {
        // Lógica para ver los detalles del evento
    };

    return (
        <div className="container">
            <Navbar />
            <br />
            <div className="row align-items-center">
                <div className="col">
                    <h1>Listado de Safj Eventos</h1>
                </div>
                <div className="col">
                    <img
                        src="https://res.cloudinary.com/dgm059qwp/image/upload/v1680588126/Black_and_Gold_Classy_Minimalist_Circular_Name_Logo-removebg-preview_rfjd8f.png"
                        className="img-fluid"
                        style={{ maxHeight: '120px' }}
                    />
                </div>
            </div>
            
            <br />
            <div className="row">
                <div className="col">
                    <table className="table table-hover">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Fecha</th>
                                <th>Detalles</th>
                            </tr>
                        </thead>
                        <tbody>
                            {eventos.map((evento) => (
                                <tr key={evento.id}>
                                    <td>{evento.descripcion}</td>
                                    <td>{evento.fecha}</td>
                                    <td>
                                        <button
                                            className="btn btn-primary"
                                            onClick={() => verDetalles(evento.id)}
                                        >
                                            Ver detalles
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default ListarEventos;

