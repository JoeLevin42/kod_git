from fastapi import FastAPI
import uvicorn

app = FastAPI()

grades = {
    "1": {"name": "Moshe", "grade": 88},
    "2": {"name": "Yaakov", "grade": 75},
    "3": {"name": "David", "grade": 92}
}

@app.get("/students")
def get_students():
    names = {"students_names": [line["name"] for line in grades.values()]}
    
    return names


@app.get("/studnts/averages")
def get_averages():
    total_grades = [line["grade"] for line in grades.values()]
    avg  = sum(total_grades) / len(total_grades)

    return {"Class average":avg}

@app.get("/students/top")
def get_top():
    max_stud = dict(max(grades.values() , key=lambda x: x["grade"]))

    return {"max_stud":max_stud}

    
@app.get("/students/{student_id}")
def one_student(student_id:str):
    
    return grades.get(student_id, "Error")

if __name__ == "__main__":
    uvicorn.run(app)