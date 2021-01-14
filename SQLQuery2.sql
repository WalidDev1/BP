create table reservation 
(
id int primary key identity,
date_reservation datetime,
idClient int references client(id),
idTrajet int references trajet(id)
)