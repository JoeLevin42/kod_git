import mysql.connector as seqel


def get_conenction():
    cnx = seqel.connect(
        host = "localhost",
        port = 3307,
        database = "soldiers_db",
        user = "root",
        password = "root"
    )

    return cnx


def get_summary():
    conn = get_conenction()
    cursor = conn.cursor(dictionary=True)

    sql_total = "SELECT COUNT(*) FROM soldiers"
    sql_total_active = "SELECT COUNT(*) FROM soldiers WHERE active = TRUE"
    cursor.execute(sql_total)

    total_row = cursor.fetchone()

    cursor.execute(sql_total_active)

    total_row_active = cursor.fetchone()


    cursor.close()
    conn.close()

    return {"total":total_row, "total_active":total_row_active, "non-active":total_row-total_row_active}

def count_by_unit():
    conn = get_conenction()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT unit , COUNT(*) as total FROM soldiers GROUP BY unit ORDER BY total DESC"

    cursor.execute(sql)

    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows


def get_missing_data():
    conn = get_conenction()
    cursor = conn.cursor(dictionary=True)

    sql = "SELECT * FROM soldiers WHERE `rank` IS NULL"

    cursor.execute(sql)
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows

def get_units_with_multiple_soldiers():
    conn = get_conenction()
    cursor = conn.cursor(dictionary=True)

    sql_query = "SELECT unit, COUNT(*) AS total FROM soldiers GROUP BY unit HAVING total>1"

    cursor.execute(sql_query)

    rows = cursor.fetchall()

    cursor.close()
    conn.close()


    return rows
if __name__ == "__main__":
    print(get_units_with_multiple_soldiers())