
CREATE VIEW view_costo
AS
  SELECT P.name as 'project', T.name as 'task', Ma.name as 'material', M.[date] as 'fecha', Ma.price as 'price', M.quantity as 'quantity', Ma.price*M.quantity as 'total'
  from [Project] as P inner join [Task] as T on P.Id= T.ProjectId inner join [materialConsume] as M on T.Id= M.TaskId inner join [material] as Ma on M.MaterialId= Ma.Id

GO
