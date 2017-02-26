declare @param_institutionName nvarchar (300)
declare @param_age bigint
declare @paramValue_Steve nvarchar (300)
declare @paramValue_Larry nvarchar (300)
declare @paramValue_A nvarchar (300)
declare @paramValue_B nvarchar (300)
declare @paramValue_D nvarchar (300)
declare @paramValue_E nvarchar (300)
declare @paramValue_F nvarchar (300)
declare @param_studentFirstName nvarchar (300)
declare @param_birthDateFloorValue datetime
declare @paramValue_Jobs nvarchar (300)

select @param_institutionName = 'Oxford University'
select @param_age = 22
select @paramValue_Steve = 'Steve'
select @paramValue_Larry = 'Larry'
select @paramValue_A = 'A'
select @paramValue_B = 'B'
select @paramValue_D = 'D'
select @paramValue_E = 'E'
select @paramValue_F = 'F'
select @param_studentFirstName = 'Steve'
select @param_birthDateFloorValue = convert (datetime, '01-Jan-1970', 106)
select @paramValue_Jobs = 'Jobs'

select
	distinct
	@param_institutionName       as InstitutionName,
	@param_age                   as Age,
	s.student_id                 as StudentId,
	s.first_name                 as StudentFirstName,
	s.last_name                  as StudentLastName,
	c.grade_number               as Grade,
	null                         as SpecialStatus,
	c.class_division             as Division,
	t.first_name                 as TeacherFirstName,
	t.last_name                  as TeacherLastName,
	t.teacher_id                 as TeacherId
from
	PQ_Student as s
		inner join PQ_ClassRoom as c on
			s.class_room_id = c.class_room_id
		inner join PQ_ClassTeacherInfo as ct on
			c.class_room_id = ct.class_room_id
		inner join PQ_Teacher as t on
			ct.teacher_id = t.teacher_id
where
	(
		(
			(
				(
					(
						(
							(
								(
									(
										(
											(
												(
													(
														s.first_name like '%Steve'
														and s.last_name like '%Jobs%'
													)
												)
												and s.first_name in (@paramValue_Steve, @paramValue_Larry)
											)
											and t.salute_text is not null
										)
										and 
										(
											(
												(
													c.class_division = @paramValue_A
													or c.class_division = @paramValue_B
												)
												and c.grade_number in (10, 11, 12)
											)
											or 
											(
												(
													c.grade_number = 1
													or c.grade_number = 2
												)
												or c.grade_number = 3
											)
										)
									)
									and c.grade_number is not null
								)
								and 
								(
									@paramValue_A = c.class_division
									or @paramValue_B = c.class_division
								)
							)
							and c.class_division not in (@paramValue_D, @paramValue_E, @paramValue_F)
						)
						and s.first_name = @param_studentFirstName
					)
					and s.student_id > 0
				)
				and s.birth_date > @param_birthDateFloorValue
			)
			and 
			(
				s.first_name = @paramValue_Steve
				or s.first_name = @paramValue_Jobs
			)
		)
		and s.birth_date < convert (datetime, '01-Jan-2000', 106)
	)
	and s.birth_date not in (convert (datetime, '01-Jan-1900', 106), convert (datetime, '01-Jan-1995', 106), convert (datetime, '01-Jan-2000', 106))
order by
	s.first_name,
	s.last_name,
	c.grade_number,
	c.class_division
