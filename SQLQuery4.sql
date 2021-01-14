create table trajet (
id int primary key identity,
Ville_depart varchar(90),
Ville_arrive varchar(90),
Date_Depart datetime,
Nbr_heure int,
idCar int references car(id),
idVile int references ville(id)


)