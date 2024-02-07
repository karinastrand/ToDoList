
using ToDoList;
bool goOn = true;
TaskList tasks = new TaskList();
//tasks.LoadTaskList();
while (goOn)
{
    Menu.ShowStartMenu();
    string MenuChoise = ReadLine();
    switch (MenuChoise)
    {
        case "1":
            {
                tasks.ShowTaskList();
                break;
            }

        case "2":
            {
                tasks.AddNewTask();
                break;
            }
        case "3":
            {
                tasks.EditTask();
                break;
            }
        case "4":
            {
                tasks.SaveTaskList();
                break;
            }
        case "5":
            {
                tasks.SaveTaskList();
                goOn = false;
                break;
            }
        default:
            {
                WriteLine("You have to choose one of the alternativ in the list");
                break;
            }

    }




}