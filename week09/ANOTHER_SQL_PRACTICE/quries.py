import mysql.connector as seqel


def get_connection():
    cnx = seqel.connect(
        host = "localhost",
        port = 3307,
        user = "root",
        password = "root",
        database = "soldiers_db",
    )

    return cnx

def get_by_rank(rank:str):
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT * FROM soldiers WHERE `rank` = %s"

    cursor.execute(sql,(rank,))

    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return  rows

def get_active_sorted(order:str):
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    if order not in ["ASC","DESC"]:
        return {"message":"Error"}
    sql = f"SELECT * FROM soldiers WHERE active = TRUE ORDER BY name {order}"

    cursor.execute(sql)

    rows = cursor.fetchall()
    cursor.close()
    conn.close()

    return rows

def get_distinct_units():
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT DISTINCT unit FROM soldiers"

    cursor.execute(sql)

    rows = cursor.fetchall()
    cursor.close()
    conn.close()

    return rows

def search_by_name(term:str):
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT * FROM soldiers WHERE name LIKE %s"

    cursor.execute(sql,(term,))
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    
    return rows

def get_by_unit(unit:str):
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT * FROM soldiers WHERE unit =%s ORDER BY name ASC"

    cursor.execute(sql,(unit,))

    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows

if __name__ == "__main__":
    pass
   