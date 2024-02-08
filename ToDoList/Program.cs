
using ToDoList;
bool goOn = true;
TaskList tasks = new TaskList();
ProjectList projects = new ProjectList();
tasks.LoadTaskList();
projects.LoadProjectList();

   
    Menu.UserInput(tasks,projects);
