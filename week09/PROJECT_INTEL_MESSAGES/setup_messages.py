import mysql.connector as seqel

def get_conn_to_conatiner():
    cnx = seqel.connect(
        host = "localhost",
        port = 3308,
        user = "root",
        password = "root"
    )

    return cnx

def create_database():
    conn = get_conn_to_conatiner()
    cursor = conn.cursor()

    sql = """
    CREATE DATABASE soldiers_db
        """
    cursor.execute(sql)

    cursor.close()
    conn.close()



def create_table_and_schema():
   conn = get_conn_to_conatiner()
   cursor = conn.cursor()

   sql_use = "USE soldiers_db"
   cursor.execute(sql_use)

   sql_create_table = """
    CREATE TABLE IF NOT EXISTS intel_messages (
    id INT PRIMARY KEY AUTO_INCREMENT,
    unit VARCHAR(100) NOT NULL,
    classification ENUM('unclassified','confidential','secret','top_secret'),
    source VARCHAR(100),
    content TEXT NOT NULL,
    created_at DATETIME DEFAULT NOW()
    )
        """
   
   cursor.execute(sql_create_table)

   cursor.close()
   conn.close()

def inset_start_data():
    conn = get_conn_to_conatiner()
    cursor = conn.cursor()

    cursor.execute("USE soldiers_db")

    sql_inset = """
    INSERT INTO intel_messages (unit, classification, content, source) VALUES
    ('8200', 'confidential', 'Suspicious movement detected near northern
    grid.', 'field agent'),
    ('8200', 'secret', 'Encrypted signal intercepted on frequency 312.',
    'sigint'),
    ('9900', 'top_secret', 'Satellite image shows vehicle convoy at dawn.',
    'satellite'),
    ('9900', 'unclassified', 'Routine patrol completed. No incidents
    reported.', NULL),
    ('8200', 'secret', 'Drone feed shows activity near the eastern
    border.','drone feed'),
    ('Unit3','confidential', 'Local source reports increased foot traffic.',
    NULL);
    """

    cursor.execute(sql_inset)
    conn.commit()
    cursor.close()
    conn.close()

if __name__ == "__main__":
    inset_start_data()

   