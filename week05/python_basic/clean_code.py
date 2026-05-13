#Ex 1
def is_adult_avtive(list_of_users :list ):
    result = []
    for x in list_of_users:
        if x[1] >= 18 and x[2] == True :
            result.append(x[0])
    return result

data_base = [
    ["data_basean", 25, True],
    ["Noa", 16, True],
    ["Yael", 30, False],
]

#print(is_adult_avtive(data_base))
#Ex 2

def is_valid_email(user_email) -> bool:
    if not user_email:
        print("Invalid User") 
        return False
    return True
def is_valid_stock( stock , quantity):
    if quantity <= 0 or quantity > stock:
        print("Invalid quanitity")
        return False
    return True
    

def price_calculator(product_price, quantity):
    final_price = product_price * quantity
    if quantity >= 10:
        final_price *= 0.9
    if quantity >= 50:
        fina_price *= 0.85  
    return final_price

def create_report(user_email, product_name, quantity , price):
    order_user = user_email
    order_product = product_name
    order_quantity = quantity
    order_total = price
    order_status = "confirmed"
    return order_user, order_product, order_quantity, order_total, order_status

def printf(report):
    print(f"Order {report[4]}: {report[0]} bought {report[2]}x {report[1]} for ${report[3]}")

def handle_purchase(user_email, product_name, product_price, stock, quantity):
    if is_valid_email(user_email) and is_valid_stock(stock , quantity):
        price = price_calculator(product_price, quantity)
        stock -= quantity
        report = create_report(user_email, product_name, quantity ,price)
        printf(report)
    else:
        print("The process failed")
#handle_purchase("Yoel@gmail","Cheese",20,50,20)

#Ex 3


def is_valid_name(new_name):
    if not new_name or len(new_name) < 2:
        print("Error: invalid name")
        return False
    
def is_valid_grade(new_grade):
    if new_grade < 0 or new_grade > 100:
        print("Error: grade must be 0-100")
        return False

def add_student(grades,new_grade):
    if not is_valid_grade(new_grade):
        grades.append(new_grade)
    print("Grade added")
    return grades

def calculate_stats(grades):
     # calculate stats
    total = sum(grades)
    average = total / len(grades)
    top_count = sum(1 for g in grades if g >= 90)
    failing_count = sum(1 for g in grades if g < 56)
    return total , average , top_count , failing_count

def printf(stats ,names ,grades ):
    average = stats[1]
    top_count = stats[2]
    failing_count = stats[3]
     # print report
    print("=== Student Report ===")
    for i in range(len(names)):
        print(f"  {names[i]}: {grades[i]}")
    print(f"Average: {average:.1f}")
    print(f"Top students: {top_count}")
    print(f"Failing: {failing_count}")

def save_to_file(names,grades):
     with open("students.txt", "w") as f:
        for i in range(len(names)):
            f.write(f"{names[i]},{grades[i]}\n")


def manage_students(names, grades, new_name, new_grade):
    add_student(grades,90)
    if is_valid_name and is_valid_grade:
        stats = calculate_stats(grades)
        printf(stats,names,grades)
        # save_to_file(names,grades)

    return names, grades

#Ex 4
def is_valid_user(name,email):
     if not name or len(name) < 2:
        raise ValueError("Invalid name")
     if "@" not in email:
        raise ValueError("Invalid email")
     return True
     
def create_user(name, email,user_type):
    if is_valid_user(name,email):
        return name, email, user_type, "2024-01-01", True

#Ex 5
def get_status(score):
    if score >= 90:
        status = "excellent"
    elif score >= 70 and score < 90:
        status = "good"
    elif score >= 55 and score < 70:
        status = "average"
    elif score < 55:
        status = "fail"
    else:
        status = "unknown"
    return status


def is_valid_age(age):
    if isinstance(age, int):
        if age > 0 and age <120: return True
        return False  

def get_greeting(hour):
    greeting = ''
    if hour >= 5 and hour < 12:
        greeting = "Good morning"
    if hour >= 12 and hour < 17:
        greeting = "Good afternoon"
    if hour >= 17 and hour < 21:
        greeting = "Good evening"
    if hour >= 21 or hour < 5:
        greeting = "Good night"
    return greeting


    

