from fastapi import FastAPI , HTTPException
import uvicorn

app = FastAPI()

@app.get("/numbers/{n}")
def numbers(n):
    if n < 0 :
        raise HTTPException(status_code = 400, detail="Please enter only postive numbers")
    
    return {"number":n}

@app.get("/students/{student_id}")
def students(student_id):

    if not student_id in students:
        raise HTTPException(status_code = 404 , detail= "The student not found")
    
    return {student_id:student_id[student_id]}
@app.post("/students/{student_id}")
def add_student(student_id,payload):
    
    if student_id  in students:
        raise HTTPException(status_code=409 , detail="the student is already exist")
    
    students[student_id] = payload
