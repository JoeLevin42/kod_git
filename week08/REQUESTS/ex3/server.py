from fastapi import FastAPI
import uvicorn


app = FastAPI()

@app.get("/greet")
def greet(name:str="World"):
    
    return {"message":f"Hello {name}!"}

if __name__ == "__main__":
    uvicorn.run(app)