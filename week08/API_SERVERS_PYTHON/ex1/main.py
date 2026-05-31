from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/ping")
def ping():
    return {"status":"pong"}


@app.get("/greet/{name}")
def greet(name :str):
    return {"message":f"Hello {name}"}


if __name__ =="__main__":
    uvicorn.run(app, host="127.0.0.1", port=8000)

