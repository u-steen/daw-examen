import Produs from "../Produs/Produs";
import {useEffect, useState} from "react";

function ProdusList() {
    const [movies, setMovies] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch("/api/produs");
            const data = await response.json();
            console.log(data);
            setMovies(data);
        }
        fetchData();
    }, []);
    return (
        <div className={"container"}>
        {movies.map(produs => (
            <div key={produs.id}>
                <Produs
                    nume = {produs.denumire}
                    pret = {produs.pret}
                />
            </div>))
        }
    </div>
    )
}

export default ProdusList