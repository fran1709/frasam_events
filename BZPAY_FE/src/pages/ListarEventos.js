import React, { useEffect, useState } from 'react';

function ListarEventos() {
    const [eventos, setEventos] = useState([]);

    useEffect(() => {
        obtenerEventos();
    }, []);

    const obtenerEventos = async () => {
        // Lógica para obtener los eventos
    };

    const verDetalles = () => {
        // Lógica para ver los detalles del evento
    };

    return (
        <div className="container">
            <h1>Listado de Safj Eventos</h1>
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
                                    <td>{evento.nombre}</td>
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

