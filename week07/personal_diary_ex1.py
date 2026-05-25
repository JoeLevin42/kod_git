import os

#Ex 1
def diary():
	try:
		with open("diary.txt","w",encoding="utf-8") as f:
			f.write("# 2024-01-15 - Its was busy day on the project\n# 2024-01-16 - I've learnd on files handeling\n# 2024-01-17 - I've did the first practice\n")
		print("The text saved in the file")
	except:
		print("Somehting went wrong")
	
	try:
		with open("diary.txt","r",encoding="utf-8") as rf:
			content = rf.read()
			print(content)
	except:
		print("something went wrong")

#Ex 2
def add_entry(filename,date,content):
	try:
		with open(filename,"a",encoding="utf-8") as f:
			f.write(f"# {date} - {content}")
	except FileNotFoundError:
		print("Sorry the file didnt found")

# add_entry("diary.txt","2024-01-18", "Wonderfull day I finished the first ex")

#Ex 3
def search_diary(filename, keyword):
	try:
		with open(filename,"r",encoding="utf-8") as f:
			content = f.read()
			line_list = content.split("\n")
			filterd_list =[]
			for line in line_list:
				if keyword in line:
					filterd_list.append(line)
			print(filterd_list)
	except FileNotFoundError:
		print("Oops something went wrong we didnt found the file")
#search_diary("diary.txt","day")

#Ex 4
def safe_read_diary(filename):
	if os.path.exists(filename):
		with open(filename, "r" ,encoding="utf-8") as f:
			conetent = f.read()
			print(conetent)
	else:
		print("Sorry something went wrong")

safe_read_diary("diary.txt")
	
	