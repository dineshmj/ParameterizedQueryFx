-- select 'INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(' + convert (varchar, class_room_id) + ', ' + convert (varchar, grade_number) + ', ''' + class_division + ''')' from [dbo].[PQ_ClassRoom]
-- select 'INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (' + convert (varchar, teacher_id) + ', ''' + salute_text + ''', ''' + first_name + ''', ''' + last_name + ''', convert (datetime, ''' + convert (varchar, birth_date, 106) + '''))' from [dbo].[PQ_Teacher] 
-- select 'INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (' + convert (varchar, class_room_id) + ', ' + convert (varchar, teacher_id) + ') '  from [dbo].[PQ_ClassTeacherInfo]
-- select 'INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(' + convert (varchar, student_id) + ', ''' + salute_text + ''', ''' + first_name + ''', ''' + last_name + ''', convert (datetime, ''' + convert (varchar, birth_date, 106) + '''), ' + convert (varchar, class_room_id) + ')' from [dbo].[PQ_Student]

INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(50, 10, 'A')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(51, 10, 'B')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(52, 10, 'C')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(54, 10, 'D')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(55, 9, 'A')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(56, 9, 'B')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(57, 9, 'C')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(58, 11, 'A')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(59, 11, 'B')
INSERT INTO [dbo].[PQ_ClassRoom] ([class_room_id],[grade_number],[class_division]) VALUES(60, 11, 'C')

INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (100, 'Mr.', 'Albert', 'Einstein', convert (datetime, '01 Jan 1976'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (101, 'Mr.', 'Issac', 'Newton', convert (datetime, '01 Jan 1976'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (102, 'Mr.', 'Neils', 'Bohr', convert (datetime, '01 Jan 1976'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (103, 'Mrs.', 'Marie', 'Curie', convert (datetime, '01 Jan 1980'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (104, 'Mr.', 'Max', 'Plank', convert (datetime, '01 Jan 1975'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (105, 'Ms.', 'Virginia', 'Apgar', convert (datetime, '01 Jan 1975'))
INSERT INTO [dbo].[PQ_Teacher] ([teacher_id],[salute_text],[first_name],[last_name],[birth_date])VALUES (106, 'Mrs.', 'Mary', 'Brush', convert (datetime, '01 Jan 1973'))

INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (50, 100) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (51, 101) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (52, 101) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (53, 103) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (54, 104) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (55, 105) 
INSERT INTO [dbo].[PQ_ClassTeacherInfo] ([class_room_id],[teacher_id]) VALUES (56, 106) 

INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(1, 'Mr.', 'Steve', 'Jobs', convert (datetime, '01 Jun 1973'), 50)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(2, 'Mrs.', 'Ursula', 'Burns', convert (datetime, '01 Jan 1980'), 51)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(3, 'Mr.', 'Bill', 'Gates', convert (datetime, '01 Jan 1978'), 51)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(4, 'Mr.', 'Larry', 'Page', convert (datetime, '01 Jan 1980'), 52)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(5, 'Ms.', 'Marissa', 'Mayer', convert (datetime, '01 Jan 1988'), 52)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(6, 'Mr.', 'Mark', 'Zuckerberg', convert (datetime, '01 Jan 1988'), 53)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(7, 'Mr.', 'Dustin', 'Moskovitz', convert (datetime, '01 Jan 1990'), 54)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(8, 'Mr.', 'Andrew', 'McCollum', convert (datetime, '01 Jan 1975'), 54)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(9, 'Mr.', 'Justin', 'Beiber', convert (datetime, '01 Jan 1980'), 55)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(10, 'Ms.', 'Jassica', 'Alba', convert (datetime, '01 Jan 1990'), 55)
INSERT INTO [dbo].[PQ_Student] ([student_id],[salute_text],[first_name],[last_name],[birth_date],[class_room_id]) VALUES(11, 'Mrs.', 'Celine', 'Dione', convert (datetime, '01 Jan 1985'), 55)
