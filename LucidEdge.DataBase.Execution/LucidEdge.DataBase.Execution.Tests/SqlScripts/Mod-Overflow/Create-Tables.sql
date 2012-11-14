CREATE TABLE Question (
	Text text,
	Title text,
	User_Id int,
	Votes_Id int,
	Answers_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Answer (
	Text text,
	IsAnswer int,
	User_Id int,
	Comment_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE [User] (
	UserName text,
	Email text,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Comment (
	Text text,
	User_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Vote (
	UpVotes int,
	DownVotes int,
	User_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
CREATE TABLE Tag (
	Name text,
	Definition text,
	Tag_Id int,
	Id int,
	Version int,
	Created_At date,
	Updated_On date
);
