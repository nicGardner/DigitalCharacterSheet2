use digitalCharacterSheet2DB;

drop table if exists characters;
create table characters (
character_name varchar(30) primary key,
campaign varchar(100),
advancement_points int,
plot_points int
);



drop table if exists attributes;
create table attributes
(
characterName varchar (30),
attributeName varchar(20),
attributeValue int, 
CONSTRAINT attributes_pk PRIMARY KEY(characterName, attributeName)
);

alter table attributes 
add constraint fk_characterName
	foreign key (characterName) references characters(character_name) on delete cascade;



