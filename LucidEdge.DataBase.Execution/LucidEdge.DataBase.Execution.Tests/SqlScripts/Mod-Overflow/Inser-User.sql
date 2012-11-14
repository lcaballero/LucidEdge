
INSERT INTO
	[USER] (
		username,
		email,
		user_id,
		version,
		created_at,
		updated_on
	)
	VALUES (
		@username,
		@email,
		@user_id,
		@version,
		@created_at,
		@updated_on
	);