use JobManagementDB

CREATE TABLE applications (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,

    job_id BIGINT NOT NULL,

    applicant_id BIGINT NOT NULL,

    resume_snapshot_url NVARCHAR(255),

    cover_letter NVARCHAR(MAX),

    status NVARCHAR(30) NOT NULL DEFAULT 'APPLIED',

    applied_at DATETIME NOT NULL DEFAULT GETUTCDATE(),

    updated_at DATETIME NULL,

    CONSTRAINT uq_job_applicant
        UNIQUE (job_id, applicant_id),

    CONSTRAINT fk_applications_job
        FOREIGN KEY (job_id)
        REFERENCES jobs(id)
        ON DELETE CASCADE,

    CONSTRAINT fk_applications_user
        FOREIGN KEY (applicant_id)
        REFERENCES users(id)
        ON DELETE NO ACTION,

  
);
