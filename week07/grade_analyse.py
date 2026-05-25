
#Ex 1
def create_grade_file(filename):
    students =[
    ("Dan", [85, 90, 78]),
    ("MOMO", [92, 88, 95]),
    ("Yoni", [70, 65, 80]),
    ("Avi", [100, 95, 98]),
    ("Sara", [60, 72, 68]),]
    with open(filename,"w",encoding="utf-8") as f:
            for line in students:
                f.write(f"{line[0]}, {str(line[1]).strip("[]")}\n")
		


#Ex 2
def calculate_averages(filename):
	avg_dict = {}
	with open(filename,"r",encoding="utf-8") as file:
          for line in file:
               
                parts = line.strip().split(",")
                name = parts[0]
                grades = [int(grade) for grade in parts[1:]]
                avg_dict[name] = (sum(grades) / len(grades))

          return avg_dict
 

#Ex 3
def save_results(averages, output_file):
    sorted_averages = dict(sorted(averages.items() , key=lambda item:item[1],reverse=True))
    
    with open(output_file, "w",encoding="utf-8") as f:
         for key , val in sorted_averages.items():
              line = f"{key} , {val:.1f}\n"
              f.write(line)
    return sorted_averages\

avg_dict = calculate_averages("grades.txt")
save_results(avg_dict, "sorted_avg.txt")

#Ex 4
def statics(sorted_avg):
    
    grade_sum = 0
    counter = 0
    for grade in sorted_avg.values():
         grade_sum += int(grade)
         counter +=1
    avg_all = grade_sum / counter

    max_grade_student = max(sorted_avg, key= sorted_avg.get)
    max_grade = sorted_avg[max_grade_student]
    max_tuple = (max_grade_student,max_grade)

    min_grade_student = min(sorted_avg, key= sorted_avg.get)
    min_grade = sorted_avg[min_grade_student]
    min_tuple = (min_grade_student,min_grade)    

    total_students = len(sorted_avg)
    passing_list =  [counter for counter in sorted_avg.values() if counter >= 60]  

    class_avg = f"Class Averege {avg_all:.1f}"
    max_in_class = f"{max_tuple[0]} , {max_tuple[1]:.1f}"
    min_in_class  = f"({min_tuple[0]} , {min_tuple[1]:.1f})"
    who_passed =  f"{len(passing_list)}/{total_students}"
		
    with open("results.txt","w",encoding="utf-8") as f:
            f.write(f"{class_avg}\n") 
            f.write(f"{max_in_class}\n")
            f.write(f"{min_in_class}\n")
            f.write(f"{who_passed}\n")
statics(avg_dict)
			
		
		