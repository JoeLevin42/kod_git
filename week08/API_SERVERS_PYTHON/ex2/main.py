from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/")
def home():
    return {"service": "my-api", "version": "1.0"}

@app.get("/users/admin")
def admin():
    return {"role": "admin", "access": "full"}

@app.get("/users/{user_id}")
def users(user_id:int=0):
    return {"email":"example@example.com","name":"Ploni","user_id":user_id}



if __name__ == "__main__":
    uvicorn.run(app)
