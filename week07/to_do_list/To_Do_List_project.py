"""
To Do List - mission manager project
"""

def load_tasks(filename)-> list[dict]:
    
    mission_dicts_list = []
    try:
        with open("tasks.txt","r",encoding="utf-8") as file:
            content = file.readlines()  
            orderd_list = []
            for item in content:
                if item.strip():
                    orderd_list.append(item.strip().split("|"))
            for task in orderd_list:
                mission_dicts_list.append({"id":task[0],"status":task[1],"desc":task[2]})
                
            return mission_dicts_list
    except FileNotFoundError:
        print("Error the file not found")


def save_tasks(filename, tasks)-> None:
    
    try:
        with open(filename , "w",encoding="utf-8") as file:
             for index , dicti in enumerate(tasks):
                if index == len(tasks) -1:
                    file.write(f"{dicti["id"]}|{dicti["status"]}|{dicti["desc"]}")
                else:
                    file.write(f"{dicti["id"]}|{dicti["status"]}|{dicti["desc"]}\n")
              
            
               
    except:
        print("Sorry something went wrong")

def add_task(filename, description):
    
    try:
        with open(filename,"r",encoding="utf-8") as r:
            content = r.readlines()
            filtered_list = [line.strip() for line in content if line.strip()]

        line_str = f"{len(filtered_list)+1}|PENDING|{description}"
        with open(filename, "a",encoding="utf-8") as file:
            file.write(f"\n{line_str}\n")

    except FileNotFoundError:
        print("Sorry the file not found")

def complete_task(filename , task_id):
    
    try:
        with open(filename, "r", encoding="utf-8") as r:
            content = r.readlines()
        new_content = []
        for line in content:
            part = line.split("|")
            if part[0] == str(task_id):
                part[1] = "DONE"
                part = "|".join(part)
                new_content.append(part)
            else:
                new_content.append(line)
        with open(filename,"w",encoding="utf-8") as file:
            file.writelines(new_content)
    except FileNotFoundError:
        print("Sorry the file not found")
        

def list_tasks(filename):
    
    mission_dict = load_tasks(filename)
    for task in mission_dict:
        print(f"{"[v]" if task["status"] == "DONE" else "[]"}|{task["id"]}|{task["desc"]}")


def main():

    FILENAME = "tasks.txt"
    while True:
        print('\n=== To-Do List Manager ===')
        print("1. Show missions")
        print("2. Add mission")
        print("3. Complete mission")
        print("4. Exit")
        choice = input("Enter your choice")

        if choice == '1':
            list_tasks(FILENAME)
        elif choice == '2':
            desc = input('Task description: ')
            add_task(FILENAME, desc)
            print('Task added!')
        elif choice == '3':
            task_id = int(input('Task number: '))
            complete_task(FILENAME, task_id)
        elif choice == '4':
            print('Goodbye!')
            break
        else:
            print('Invalid choice')

if __name__ == '__main__':
    main()
