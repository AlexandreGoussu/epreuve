Set default_storage_engine=InnoDb;

use GSB;

drop table if exists presentation;

-- création de la table Presentation

create table presentation
(
    datePresentation      date         not null primary key ,
    sujet                 varchar(150) not null
);

insert into presentation (datePresentation, sujet) values
	('2023-01-05', 'Étude de l''efficacité et de la sécurité d''un nouveau médicament LITHOR12'),
	('2023-02-05', 'Évaluation de l''utilisation du DEPRIL9 chez les personnes âgées et les enfants.'),
	('2023-03-05', 'Optimisation de la posologie'),
	('2023-10-05', 'Évaluation de l''efficacité de nos médicaments  par rapport aux médicaments génériques'),
	('2023-11-05', 'Analyse des effets secondaires de nos médicaments et de leur impact sur la qualité de vie des patients'),
	('2023-12-05', 'Efficacité de nos médicaments combinés pour le traitement de maladies chroniques');

-- création du déclencheur demandé

drop trigger if exists avantAjoutPresentation;

create trigger avantAjoutPresentation before insert on presentation
for each row
begin
    -- une seule présentation par moi
    if exists (select 1 from presentation where month(datePresentation) = month(new.datePresentation)) then
          SIGNAL sqlstate '45000' set message_text =
                'Il existe déjà une présentation programmée dans ce mois';
    end if;
    -- une présentation doit être planifiée au moins un mois à l'avance
    if new.datePresentation < curdate() + interval 1 month then
          SIGNAL sqlstate '45000' set message_text =
                'Une présentation doit être planifiée au moins un mois à l''avance ';
    end if;
end;


--  Création des procédures stockées

-- Inscrire une nouvelle présentation

drop procedure if exists ajouterPresentation ;
create procedure ajouterPresentation(_datePresentation date, _sujet varchar(150)) sql security definer
begin
	insert into presentation(datePresentation, sujet) values (_datePresentation, _sujet);
end;


-- Création des présentations en ligne
delete presentation from date where date < now() - interval 1DAY;

