create database JobManagementDB


use JobManagementDB



CREATE TABLE roles (
    id INT IDENTITY(1,1) PRIMARY KEY,

    role_name NVARCHAR(50) NOT NULL UNIQUE,

	code INT UNIQUE NOT NULL,

    description NVARCHAR(200),

    created_at DATETIME NOT NULL DEFAULT GETUTCDATE(),

    updated_at DATETIME NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE users (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,

    role_id INT NOT NULL,

    full_name NVARCHAR(100) NOT NULL,

    email NVARCHAR(150) NOT NULL UNIQUE,

    password_hash NVARCHAR(255) NOT NULL,

    phone NVARCHAR(15),


    created_at DATETIME NOT NULL DEFAULT GETUTCDATE(),

    updated_at DATETIME NOT NULL DEFAULT GETUTCDATE(),

   
        FOREIGN KEY (role_id)
        REFERENCES roles(id)
);
