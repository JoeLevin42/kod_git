from fastapi import FastAPI
import uvicorn
import reports

app = FastAPI()

@app.get("/stats/summary")
def get_summary():
    return reports.get_summary()

@app.get("/satas/unit")
def get_units():
    return reports.count_by_unit()

@app.get("/stats/understaffed")
def get_understaffed():
    return reports.get_units_with_multiple_soldiers()

@app.get("/soldiers/missing-rank")
def get_missing_rank():
    return reports.get_missing_data()


@app.get("/soldiers")
def get_with_params(rank: str = None ,sort:str = "ASC",unit:str = None):
    if sort == "DESC":
        pass
    elif sort == "ASC":
        pass
    else:
        raise ValueError("This not valid sort parm")
    
    if rank:
        q
