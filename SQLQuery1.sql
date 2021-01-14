create table trajet 
(
id int primary key identity,
Ville_depart  varchar(50),
Ville_arrive  varchar(50),
Date_depart datetime,
Nbr_heure int,
idCar int references car(id),
idVille int references ville(id)
)