user OJS
go

Delete ProblemsTestCases
delete ProblemsInContest
delete MyNotification
delete Notification
delete MyContest
delete Contests
delete Problems
Delete Users

go

DBCC checkident ('[ProblemsTestCases]', reseed, 0)
DBCC checkident ('[ProblemsInContest]', reseed, 0)
DBCC checkident ('[MyNotification]', reseed, 0)
DBCC checkident ('[Notification]', reseed, 0)
DBCC checkident ('[MyContest]', reseed, 0)
DBCC checkident ('[Contests]', reseed, 0)
DBCC checkident ('[Problems]', reseed, 0)
DBCC checkident ('[Users]', reseed, 0)