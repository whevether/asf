--
-- PostgreSQL database dump
--

-- Dumped from database version 15.0 (Debian 15.0-1.pgdg110+1)
-- Dumped by pg_dump version 15.0 (Debian 15.0-1.pgdg110+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

ALTER TABLE IF EXISTS ONLY "public"."asf_account_post" DROP CONSTRAINT IF EXISTS "post_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_role_permission" DROP CONSTRAINT IF EXISTS "permission_role_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_role_permission" DROP CONSTRAINT IF EXISTS "permission_permission_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_department_role" DROP CONSTRAINT IF EXISTS "dept_role_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_department_role" DROP CONSTRAINT IF EXISTS "dept_department_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_apis" DROP CONSTRAINT IF EXISTS "api_permission_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_role" DROP CONSTRAINT IF EXISTS "account_role_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_post" DROP CONSTRAINT IF EXISTS "account_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_role" DROP CONSTRAINT IF EXISTS "account_account_id_foreign";
ALTER TABLE IF EXISTS ONLY "public"."asf_permission_menu" DROP CONSTRAINT IF EXISTS "FK_asf_permission_menu_asf_permission_permission_id";
ALTER TABLE IF EXISTS ONLY "public"."asf_accounts" DROP CONSTRAINT IF EXISTS "FK_asf_accounts_asf_tenancy_tenancy_id";
ALTER TABLE IF EXISTS ONLY "public"."asf_accounts" DROP CONSTRAINT IF EXISTS "FK_asf_accounts_asf_department_department_id";
DROP INDEX IF EXISTS "public"."IX_asf_translate_value";
DROP INDEX IF EXISTS "public"."IX_asf_role_permission_role_id";
DROP INDEX IF EXISTS "public"."IX_asf_role_permission_permission_id";
DROP INDEX IF EXISTS "public"."IX_asf_permission_name";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_title";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_permission_id";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_menu_url";
DROP INDEX IF EXISTS "public"."IX_asf_dictionary_key";
DROP INDEX IF EXISTS "public"."IX_asf_department_role_role_id";
DROP INDEX IF EXISTS "public"."IX_asf_department_role_department_id";
DROP INDEX IF EXISTS "public"."IX_asf_apis_permission_id";
DROP INDEX IF EXISTS "public"."IX_asf_apis_path";
DROP INDEX IF EXISTS "public"."IX_asf_apis_name";
DROP INDEX IF EXISTS "public"."IX_asf_accounts_username";
DROP INDEX IF EXISTS "public"."IX_asf_accounts_tenancy_id";
DROP INDEX IF EXISTS "public"."IX_asf_accounts_email";
DROP INDEX IF EXISTS "public"."IX_asf_accounts_department_id";
DROP INDEX IF EXISTS "public"."IX_asf_account_role_role_id";
DROP INDEX IF EXISTS "public"."IX_asf_account_role_account_id";
DROP INDEX IF EXISTS "public"."IX_asf_account_post_post_id";
DROP INDEX IF EXISTS "public"."IX_asf_account_post_account_id";
ALTER TABLE IF EXISTS ONLY "public"."asf_translate" DROP CONSTRAINT IF EXISTS "PK_asf_translate";
ALTER TABLE IF EXISTS ONLY "public"."asf_tenancy" DROP CONSTRAINT IF EXISTS "PK_asf_tenancy";
ALTER TABLE IF EXISTS ONLY "public"."asf_security_token" DROP CONSTRAINT IF EXISTS "PK_asf_security_token";
ALTER TABLE IF EXISTS ONLY "public"."asf_scheduled_task" DROP CONSTRAINT IF EXISTS "PK_asf_scheduled_task";
ALTER TABLE IF EXISTS ONLY "public"."asf_role_permission" DROP CONSTRAINT IF EXISTS "PK_asf_role_permission";
ALTER TABLE IF EXISTS ONLY "public"."asf_role" DROP CONSTRAINT IF EXISTS "PK_asf_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_post" DROP CONSTRAINT IF EXISTS "PK_asf_post";
ALTER TABLE IF EXISTS ONLY "public"."asf_permission_menu" DROP CONSTRAINT IF EXISTS "PK_asf_permission_menu";
ALTER TABLE IF EXISTS ONLY "public"."asf_permission" DROP CONSTRAINT IF EXISTS "PK_asf_permission";
ALTER TABLE IF EXISTS ONLY "public"."asf_loginfos" DROP CONSTRAINT IF EXISTS "PK_asf_loginfos";
ALTER TABLE IF EXISTS ONLY "public"."asf_dictionary" DROP CONSTRAINT IF EXISTS "PK_asf_dictionary";
ALTER TABLE IF EXISTS ONLY "public"."asf_department_role" DROP CONSTRAINT IF EXISTS "PK_asf_department_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_department" DROP CONSTRAINT IF EXISTS "PK_asf_department";
ALTER TABLE IF EXISTS ONLY "public"."asf_apis" DROP CONSTRAINT IF EXISTS "PK_asf_apis";
ALTER TABLE IF EXISTS ONLY "public"."asf_accounts" DROP CONSTRAINT IF EXISTS "PK_asf_accounts";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_role" DROP CONSTRAINT IF EXISTS "PK_asf_account_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_post" DROP CONSTRAINT IF EXISTS "PK_asf_account_post";
DROP SEQUENCE IF EXISTS "public"."asf_translate_id_seq";
DROP TABLE IF EXISTS "public"."asf_translate";
DROP SEQUENCE IF EXISTS "public"."asf_tenancy_id_seq";
DROP TABLE IF EXISTS "public"."asf_tenancy";
DROP SEQUENCE IF EXISTS "public"."asf_security_token_id_seq";
DROP TABLE IF EXISTS "public"."asf_security_token";
DROP SEQUENCE IF EXISTS "public"."asf_scheduled_task_id_seq";
DROP TABLE IF EXISTS "public"."asf_scheduled_task";
DROP SEQUENCE IF EXISTS "public"."asf_role_permission_id_seq";
DROP TABLE IF EXISTS "public"."asf_role_permission";
DROP SEQUENCE IF EXISTS "public"."asf_role_id_seq";
DROP TABLE IF EXISTS "public"."asf_role";
DROP SEQUENCE IF EXISTS "public"."asf_post_id_seq";
DROP TABLE IF EXISTS "public"."asf_post";
DROP SEQUENCE IF EXISTS "public"."asf_permission_menu_id_seq";
DROP TABLE IF EXISTS "public"."asf_permission_menu";
DROP SEQUENCE IF EXISTS "public"."asf_permission_id_seq";
DROP TABLE IF EXISTS "public"."asf_permission";
DROP SEQUENCE IF EXISTS "public"."asf_loginfos_id_seq";
DROP TABLE IF EXISTS "public"."asf_loginfos";
DROP SEQUENCE IF EXISTS "public"."asf_dictionary_id_seq";
DROP TABLE IF EXISTS "public"."asf_dictionary";
DROP SEQUENCE IF EXISTS "public"."asf_department_role_id_seq";
DROP TABLE IF EXISTS "public"."asf_department_role";
DROP SEQUENCE IF EXISTS "public"."asf_department_id_seq";
DROP TABLE IF EXISTS "public"."asf_department";
DROP SEQUENCE IF EXISTS "public"."asf_apis_id_seq";
DROP TABLE IF EXISTS "public"."asf_apis";
DROP SEQUENCE IF EXISTS "public"."asf_accounts_id_seq";
DROP TABLE IF EXISTS "public"."asf_accounts";
DROP SEQUENCE IF EXISTS "public"."asf_account_role_id_seq";
DROP TABLE IF EXISTS "public"."asf_account_role";
DROP SEQUENCE IF EXISTS "public"."asf_account_post_id_seq";
DROP TABLE IF EXISTS "public"."asf_account_post";
--
-- Name: SCHEMA "public"; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON SCHEMA "public" IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = "heap";

--
-- Name: asf_account_post; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_account_post" (
    "id" bigint NOT NULL,
    "account_id" bigint NOT NULL,
    "post_id" bigint NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_account_post"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_account_post" IS '账户岗位中间表';


--
-- Name: COLUMN "asf_account_post"."account_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_account_post"."account_id" IS '账户id';


--
-- Name: COLUMN "asf_account_post"."post_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_account_post"."post_id" IS '岗位id';


--
-- Name: asf_account_post_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_account_post_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_account_post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_account_post_id_seq" OWNED BY "public"."asf_account_post"."id";


--
-- Name: asf_account_post_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_account_post" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_account_post_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_account_role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_account_role" (
    "id" bigint NOT NULL,
    "account_id" bigint NOT NULL,
    "role_id" bigint NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_account_role"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_account_role" IS '账户角色中间表';


--
-- Name: COLUMN "asf_account_role"."account_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_account_role"."account_id" IS '账户id';


--
-- Name: COLUMN "asf_account_role"."role_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_account_role"."role_id" IS '角色id';


--
-- Name: asf_account_role_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_account_role_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_account_role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_account_role_id_seq" OWNED BY "public"."asf_account_role"."id";


--
-- Name: asf_account_role_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_account_role" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_account_role_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_accounts; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_accounts" (
    "id" bigint NOT NULL,
    "tenancy_id" bigint,
    "department_id" bigint,
    "name" character varying(20) NOT NULL,
    "username" character varying(32) NOT NULL,
    "password" character varying(255) NOT NULL,
    "password_salt" character varying(255) NOT NULL,
    "telphone" character varying(20),
    "email" character varying(30),
    "avatar" character varying(255),
    "status" bigint DEFAULT 1,
    "is_deleted" bigint DEFAULT 0,
    "sex" bigint,
    "create_id" bigint DEFAULT 0,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "login_ip" character varying(20),
    "login_time" timestamp(6) with time zone,
    "login_location" character varying(50),
    "token" character varying(1000),
    "refresh_token" character varying(1000),
    "expired" timestamp(6) with time zone
);


--
-- Name: TABLE "asf_accounts"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_accounts" IS '账户表';


--
-- Name: COLUMN "asf_accounts"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_accounts"."department_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."department_id" IS '部门id';


--
-- Name: COLUMN "asf_accounts"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."name" IS '账户昵称';


--
-- Name: COLUMN "asf_accounts"."username"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."username" IS '用户名';


--
-- Name: COLUMN "asf_accounts"."password"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."password" IS '账户密码';


--
-- Name: COLUMN "asf_accounts"."password_salt"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."password_salt" IS '密码加盐';


--
-- Name: COLUMN "asf_accounts"."telphone"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."telphone" IS '账户手机号码';


--
-- Name: COLUMN "asf_accounts"."email"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."email" IS '账户邮箱';


--
-- Name: COLUMN "asf_accounts"."avatar"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."avatar" IS '账户头像';


--
-- Name: COLUMN "asf_accounts"."status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."status" IS '账户状态, 1允许登录， 0禁止登录';


--
-- Name: COLUMN "asf_accounts"."is_deleted"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."is_deleted" IS '是否删除, 0 否, 1是';


--
-- Name: COLUMN "asf_accounts"."sex"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."sex" IS '性别 0 未知，1，男，2，女';


--
-- Name: COLUMN "asf_accounts"."create_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."create_id" IS '创建用户id';


--
-- Name: COLUMN "asf_accounts"."login_ip"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."login_ip" IS '最后登录ip';


--
-- Name: COLUMN "asf_accounts"."login_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."login_time" IS '最后登录时间';


--
-- Name: COLUMN "asf_accounts"."login_location"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."login_location" IS '最后登录位置';


--
-- Name: COLUMN "asf_accounts"."token"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."token" IS 'token';


--
-- Name: COLUMN "asf_accounts"."refresh_token"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."refresh_token" IS '刷新token';


--
-- Name: COLUMN "asf_accounts"."expired"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_accounts"."expired" IS '过期时间';


--
-- Name: asf_accounts_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_accounts_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_accounts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_accounts_id_seq" OWNED BY "public"."asf_accounts"."id";


--
-- Name: asf_accounts_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_accounts" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_accounts_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_apis; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_apis" (
    "id" bigint NOT NULL,
    "permission_id" bigint,
    "name" character varying(100) NOT NULL,
    "status" bigint DEFAULT 1,
    "type" bigint,
    "path" character varying(500),
    "http_methods" character varying(100),
    "is_logger" bigint DEFAULT 0,
    "description" character varying(200),
    "is_system" bigint DEFAULT 0,
    "tenancy_id" bigint,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_apis"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_apis" IS 'api表';


--
-- Name: COLUMN "asf_apis"."permission_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."permission_id" IS '权限id';


--
-- Name: COLUMN "asf_apis"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."name" IS 'api';


--
-- Name: COLUMN "asf_apis"."status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."status" IS 'api状态';


--
-- Name: COLUMN "asf_apis"."type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."type" IS 'api类型 1. openapi， 2, authapi';


--
-- Name: COLUMN "asf_apis"."path"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."path" IS 'api地址';


--
-- Name: COLUMN "asf_apis"."http_methods"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."http_methods" IS 'http 方法';


--
-- Name: COLUMN "asf_apis"."is_logger"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."is_logger" IS '是否记录日志';


--
-- Name: COLUMN "asf_apis"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."description" IS '备注';


--
-- Name: COLUMN "asf_apis"."is_system"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."is_system" IS '是否为系统权限 0 否， 1是';


--
-- Name: COLUMN "asf_apis"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_apis"."tenancy_id" IS '租户id';


--
-- Name: asf_apis_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_apis_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_apis_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_apis_id_seq" OWNED BY "public"."asf_apis"."id";


--
-- Name: asf_apis_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_apis" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_apis_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_department; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_department" (
    "id" bigint NOT NULL,
    "pid" bigint DEFAULT 0 NOT NULL,
    "tenancy_id" bigint,
    "name" character varying(255) NOT NULL,
    "enable" bigint DEFAULT 1,
    "sort" integer DEFAULT 0,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_department"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_department" IS '部门表';


--
-- Name: COLUMN "asf_department"."pid"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department"."pid" IS '父id';


--
-- Name: COLUMN "asf_department"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_department"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department"."name" IS '部门名称';


--
-- Name: COLUMN "asf_department"."enable"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department"."enable" IS '是否启用';


--
-- Name: COLUMN "asf_department"."sort"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department"."sort" IS '排序';


--
-- Name: asf_department_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_department_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_department_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_department_id_seq" OWNED BY "public"."asf_department"."id";


--
-- Name: asf_department_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_department" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_department_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_department_role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_department_role" (
    "id" bigint NOT NULL,
    "role_id" bigint NOT NULL,
    "department_id" bigint NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_department_role"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_department_role" IS '部门-角色中间表';


--
-- Name: COLUMN "asf_department_role"."role_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department_role"."role_id" IS '角色id';


--
-- Name: COLUMN "asf_department_role"."department_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_department_role"."department_id" IS '部门id';


--
-- Name: asf_department_role_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_department_role_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_department_role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_department_role_id_seq" OWNED BY "public"."asf_department_role"."id";


--
-- Name: asf_department_role_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_department_role" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_department_role_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_dictionary; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_dictionary" (
    "id" bigint NOT NULL,
    "name" "text",
    "code" character varying(255),
    "tenancy_id" bigint,
    "key" character varying(255),
    "value" character varying(255),
    "options" character varying(255),
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_dictionary"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_dictionary" IS '字典表';


--
-- Name: COLUMN "asf_dictionary"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."name" IS '字典名称';


--
-- Name: COLUMN "asf_dictionary"."code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."code" IS '字典编码';


--
-- Name: COLUMN "asf_dictionary"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_dictionary"."key"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."key" IS '字典键';


--
-- Name: COLUMN "asf_dictionary"."value"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."value" IS '字典值';


--
-- Name: COLUMN "asf_dictionary"."options"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."options" IS '字典额外配置';


--
-- Name: asf_dictionary_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_dictionary_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_dictionary_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_dictionary_id_seq" OWNED BY "public"."asf_dictionary"."id";


--
-- Name: asf_dictionary_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_dictionary" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_dictionary_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_loginfos; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_loginfos" (
    "id" bigint NOT NULL,
    "account_id" bigint,
    "account_name" character varying(32),
    "type" bigint NOT NULL,
    "subject" character varying(200) NOT NULL,
    "client_ip" character varying(20),
    "client_location" character varying(50),
    "permission_id" bigint,
    "add_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "api_address" character varying(500),
    "api_request" "text",
    "api_response" "text",
    "remark" character varying(500)
);


--
-- Name: TABLE "asf_loginfos"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_loginfos" IS '日志表';


--
-- Name: COLUMN "asf_loginfos"."account_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."account_id" IS '账户id';


--
-- Name: COLUMN "asf_loginfos"."account_name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."account_name" IS '账户名称';


--
-- Name: COLUMN "asf_loginfos"."type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."type" IS '日志类型，1： 登录日志， 2:操作日志,3 错误日志';


--
-- Name: COLUMN "asf_loginfos"."subject"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."subject" IS '登录方式';


--
-- Name: COLUMN "asf_loginfos"."client_ip"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."client_ip" IS '客户端ip';


--
-- Name: COLUMN "asf_loginfos"."client_location"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."client_location" IS '客户端位置';


--
-- Name: COLUMN "asf_loginfos"."permission_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."permission_id" IS '权限id';


--
-- Name: COLUMN "asf_loginfos"."api_address"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."api_address" IS 'api请求地址';


--
-- Name: COLUMN "asf_loginfos"."api_request"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."api_request" IS 'api请求数据';


--
-- Name: COLUMN "asf_loginfos"."api_response"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."api_response" IS 'api响应数据';


--
-- Name: COLUMN "asf_loginfos"."remark"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_loginfos"."remark" IS '备注';


--
-- Name: asf_loginfos_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_loginfos_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_loginfos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_loginfos_id_seq" OWNED BY "public"."asf_loginfos"."id";


--
-- Name: asf_loginfos_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_loginfos" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_loginfos_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_permission; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_permission" (
    "id" bigint NOT NULL,
    "code" character varying(255),
    "parent_id" bigint DEFAULT 0,
    "name" character varying(100) NOT NULL,
    "type" bigint NOT NULL,
    "is_system" bigint DEFAULT 0,
    "description" character varying(200),
    "sort" integer DEFAULT 0,
    "enable" bigint DEFAULT 1,
    "tenancy_id" bigint,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_permission"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_permission" IS '权限表';


--
-- Name: COLUMN "asf_permission"."code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."code" IS '权限代码';


--
-- Name: COLUMN "asf_permission"."parent_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."parent_id" IS '上级id';


--
-- Name: COLUMN "asf_permission"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."name" IS '权限名';


--
-- Name: COLUMN "asf_permission"."type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."type" IS '权限类型 1. 菜单目录, 2菜单条目权限, ,3 功能';


--
-- Name: COLUMN "asf_permission"."is_system"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."is_system" IS '是否为系统权限 0 否， 1是';


--
-- Name: COLUMN "asf_permission"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."description" IS '备注';


--
-- Name: COLUMN "asf_permission"."sort"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."sort" IS '排序';


--
-- Name: COLUMN "asf_permission"."enable"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."enable" IS '是否启用';


--
-- Name: COLUMN "asf_permission"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission"."tenancy_id" IS '租户id';


--
-- Name: asf_permission_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_permission_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_permission_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_permission_id_seq" OWNED BY "public"."asf_permission"."id";


--
-- Name: asf_permission_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_permission" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_permission_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_permission_menu; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_permission_menu" (
    "id" bigint NOT NULL,
    "permission_id" bigint NOT NULL,
    "title" character varying(20),
    "subtitle" character varying(100),
    "icon" character varying(250),
    "menu_hidden" bigint DEFAULT 0,
    "menu_url" character varying(250),
    "external_link" character varying(250),
    "menu_redirect" character varying(250),
    "description" character varying(500),
    "translate" character varying(500),
    "tenancy_id" bigint,
    "is_system" bigint DEFAULT 0,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_permission_menu"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_permission_menu" IS '菜单表';


--
-- Name: COLUMN "asf_permission_menu"."permission_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."permission_id" IS '权限id';


--
-- Name: COLUMN "asf_permission_menu"."title"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."title" IS '菜单标题';


--
-- Name: COLUMN "asf_permission_menu"."subtitle"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."subtitle" IS '菜单副标题';


--
-- Name: COLUMN "asf_permission_menu"."icon"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."icon" IS '菜单图标';


--
-- Name: COLUMN "asf_permission_menu"."menu_hidden"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."menu_hidden" IS '是否隐藏, 0 否 1 是';


--
-- Name: COLUMN "asf_permission_menu"."menu_url"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."menu_url" IS '菜单地址';


--
-- Name: COLUMN "asf_permission_menu"."external_link"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."external_link" IS '外部链接地址';


--
-- Name: COLUMN "asf_permission_menu"."menu_redirect"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."menu_redirect" IS '菜单重定向地址';


--
-- Name: COLUMN "asf_permission_menu"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."description" IS '菜单备注';


--
-- Name: COLUMN "asf_permission_menu"."translate"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."translate" IS '菜单多语言';


--
-- Name: COLUMN "asf_permission_menu"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_permission_menu"."is_system"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_permission_menu"."is_system" IS '是否为系统菜单';


--
-- Name: asf_permission_menu_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_permission_menu_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_permission_menu_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_permission_menu_id_seq" OWNED BY "public"."asf_permission_menu"."id";


--
-- Name: asf_permission_menu_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_permission_menu" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_permission_menu_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_post; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_post" (
    "id" bigint NOT NULL,
    "tenancy_id" bigint,
    "name" character varying(255) NOT NULL,
    "sort" integer DEFAULT 0 NOT NULL,
    "create_id" bigint DEFAULT 0,
    "description" character varying(255),
    "enable" bigint DEFAULT 1,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_post"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_post" IS '岗位表';


--
-- Name: COLUMN "asf_post"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_post"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."name" IS '岗位名称名称';


--
-- Name: COLUMN "asf_post"."sort"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."sort" IS '排序';


--
-- Name: COLUMN "asf_post"."create_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."create_id" IS '创建者id';


--
-- Name: COLUMN "asf_post"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."description" IS '岗位名称名称';


--
-- Name: COLUMN "asf_post"."enable"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_post"."enable" IS '是否启用, 0 禁用 1 启用';


--
-- Name: asf_post_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_post_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_post_id_seq" OWNED BY "public"."asf_post"."id";


--
-- Name: asf_post_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_post" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_post_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_role" (
    "id" bigint NOT NULL,
    "tenancy_id" bigint,
    "name" character varying(20) NOT NULL,
    "description" character varying(200),
    "enable" bigint DEFAULT 1,
    "create_id" bigint DEFAULT 0 NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_role"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_role" IS '角色表';


--
-- Name: COLUMN "asf_role"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_role"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role"."name" IS '角色名称';


--
-- Name: COLUMN "asf_role"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role"."description" IS '备注';


--
-- Name: COLUMN "asf_role"."enable"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role"."enable" IS '是否启用';


--
-- Name: COLUMN "asf_role"."create_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role"."create_id" IS '创建用户id';


--
-- Name: asf_role_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_role_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_role_id_seq" OWNED BY "public"."asf_role"."id";


--
-- Name: asf_role_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_role" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_role_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_role_permission; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_role_permission" (
    "id" bigint NOT NULL,
    "permission_id" bigint NOT NULL,
    "role_id" bigint NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_role_permission"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_role_permission" IS '角色权限中间表';


--
-- Name: COLUMN "asf_role_permission"."permission_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role_permission"."permission_id" IS '权限id';


--
-- Name: COLUMN "asf_role_permission"."role_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_role_permission"."role_id" IS '角色id';


--
-- Name: asf_role_permission_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_role_permission_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_role_permission_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_role_permission_id_seq" OWNED BY "public"."asf_role_permission"."id";


--
-- Name: asf_role_permission_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_role_permission" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_role_permission_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_scheduled_task; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_scheduled_task" (
    "id" bigint NOT NULL,
    "name" character varying(255) NOT NULL,
    "description" character varying(255),
    "url" character varying(255),
    "code" character varying(255),
    "task_username" character varying(255),
    "error_email" character varying(255),
    "cron" character varying(255),
    "fail_stop" integer DEFAULT 0,
    "task_status" integer DEFAULT 0,
    "params_content" character varying(255),
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_scheduled_task"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_scheduled_task" IS '任务调度表';


--
-- Name: COLUMN "asf_scheduled_task"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."name" IS '任务名称';


--
-- Name: COLUMN "asf_scheduled_task"."description"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."description" IS '调度任务描述';


--
-- Name: COLUMN "asf_scheduled_task"."url"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."url" IS '调度任务执行地址';


--
-- Name: COLUMN "asf_scheduled_task"."code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."code" IS '调度任务执行代码只限于c#代码';


--
-- Name: COLUMN "asf_scheduled_task"."task_username"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."task_username" IS '任务负责人';


--
-- Name: COLUMN "asf_scheduled_task"."error_email"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."error_email" IS '告警通知邮箱';


--
-- Name: COLUMN "asf_scheduled_task"."cron"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."cron" IS 'cron 表达式';


--
-- Name: COLUMN "asf_scheduled_task"."fail_stop"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."fail_stop" IS '失败后暂停执行, 0:失败后不停止，1,失败后停止';


--
-- Name: COLUMN "asf_scheduled_task"."task_status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."task_status" IS '任务状态， 0:停止,1:启动';


--
-- Name: COLUMN "asf_scheduled_task"."params_content"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_scheduled_task"."params_content" IS '参数内容';


--
-- Name: asf_scheduled_task_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_scheduled_task_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_scheduled_task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_scheduled_task_id_seq" OWNED BY "public"."asf_scheduled_task"."id";


--
-- Name: asf_scheduled_task_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_scheduled_task" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_scheduled_task_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_security_token; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_security_token" (
    "id" bigint NOT NULL,
    "account_id" bigint,
    "token" character varying(1000),
    "token_expired" timestamp(6) with time zone,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_security_token"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_security_token" IS 'token黑名单表';


--
-- Name: COLUMN "asf_security_token"."account_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_security_token"."account_id" IS '账户id';


--
-- Name: COLUMN "asf_security_token"."token"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_security_token"."token" IS '黑名单token';


--
-- Name: COLUMN "asf_security_token"."token_expired"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_security_token"."token_expired" IS '黑名单token过期时间';


--
-- Name: asf_security_token_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_security_token_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_security_token_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_security_token_id_seq" OWNED BY "public"."asf_security_token"."id";


--
-- Name: asf_security_token_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_security_token" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_security_token_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_tenancy; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_tenancy" (
    "id" bigint NOT NULL,
    "name" character varying(255) NOT NULL,
    "sort" integer DEFAULT 0,
    "level" integer DEFAULT 0,
    "create_id" bigint DEFAULT 0,
    "status" bigint DEFAULT 1,
    "is_deleted" bigint DEFAULT 0,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_tenancy"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_tenancy" IS '多租户';


--
-- Name: COLUMN "asf_tenancy"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."name" IS '租户名称';


--
-- Name: COLUMN "asf_tenancy"."sort"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."sort" IS '排序';


--
-- Name: COLUMN "asf_tenancy"."level"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."level" IS '等级';


--
-- Name: COLUMN "asf_tenancy"."create_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."create_id" IS '创建者id';


--
-- Name: COLUMN "asf_tenancy"."status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."status" IS '租户状态 0禁用， 1启用';


--
-- Name: COLUMN "asf_tenancy"."is_deleted"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_tenancy"."is_deleted" IS '是否删除, 0 否, 1是';


--
-- Name: asf_tenancy_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_tenancy_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_tenancy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_tenancy_id_seq" OWNED BY "public"."asf_tenancy"."id";


--
-- Name: asf_tenancy_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_tenancy" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_tenancy_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_translate; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_translate" (
    "id" bigint NOT NULL,
    "name" character varying(250),
    "tenancy_id" bigint,
    "languages" character varying(250),
    "key" character varying(500),
    "value" character varying(500)
);


--
-- Name: TABLE "asf_translate"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_translate" IS '多语言表';


--
-- Name: COLUMN "asf_translate"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."name" IS '多语言名称';


--
-- Name: COLUMN "asf_translate"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_translate"."languages"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."languages" IS '多语言名称';


--
-- Name: COLUMN "asf_translate"."key"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."key" IS '多语言key';


--
-- Name: COLUMN "asf_translate"."value"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."value" IS '多语言值';


--
-- Name: asf_translate_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE "public"."asf_translate_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: asf_translate_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE "public"."asf_translate_id_seq" OWNED BY "public"."asf_translate"."id";


--
-- Name: asf_translate_id_seq1; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_translate" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_translate_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: asf_account_post; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_account_post" VALUES (1, 1, 3, '2022-11-19 12:47:27.009327');
INSERT INTO "public"."asf_account_post" VALUES (2, 1, 7, '2022-11-19 12:47:27.011443');
INSERT INTO "public"."asf_account_post" VALUES (3, 348851403578789888, 3, '2022-11-19 15:30:56.104313');
INSERT INTO "public"."asf_account_post" VALUES (4, 348851403578789888, 7, '2022-11-19 15:30:56.104313');


--
-- Data for Name: asf_account_role; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_account_role" VALUES (1, 1, 3, '2022-11-19 12:47:27.013087');


--
-- Data for Name: asf_accounts; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_accounts" VALUES (348851403578789888, 1, 2, 'test', 'test111', 'cu7mQ8t0LplfAp5GiAbi/6dwkZhZcM/anBnxn9Pn/6E=', 'bfdf4f78-27fd-43d4-b24f-c11824d27b8b', '86+', NULL, NULL, 1, 0, 2, 1, '2022-11-19 15:30:56.104313', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."asf_accounts" VALUES (1, 1, 2, 'keep_wan', 'admin', '20V6MgmX8XVtiRz10AI4Ib5H16a9JyrNmSwmgJ2k0iI=', '8283e4c3-f87e-4d85-85fb-f5c0de063992', '86+13800000000', 'admin@qq.com', 'https://minioapi.zytravel.shop/avatar/333128767074963456avatarGroup1052.png', 1, 0, 1, 0, '2021-11-15 07:21:24.550098', '127.0.0.1', '2023-03-25 09:05:34.755123+00', '本地', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNjc5NzM1MTM0LCJleHAiOjE2Nzk4MjE1MzQsImlhdCI6MTY3OTczNTEzNCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.TpANCDNkFw2XfpnL9tAwy3TMMuWvShEFbttnWebGJnU2FMs6ek6hdsJHLDW0nDPb2kLZiOhUntaO__QrR-mnF7qwj7LAienq_2K3jtW9MBQDNdlkd054eYFYY1h_I15K8wYNt6ub0edcUPBLGJUwjnNUV-_VUiwabRyBgYU734VzDSusUyXbQN6yztVnjmSOnk7mh2nColcnJnk_g_hyg6sm_TdeAUY5z5hpc98yAlgOhAGzDY48CwWyjNfUgFnohxe-EyoeHy-VKSG0m_NDbXcFuwkaUJQXst08v6fezE6-3o6qL0hJXItngxs7rJLqUoL0kwYIgKWnIRaY3cV5eQ', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNjc5NzM1MTM0LCJleHAiOjE2Nzk4NjQ3MzQsImlhdCI6MTY3OTczNTEzNCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.TGHHji8FQfb61R124f4d8cfwLxLreMbj-96lABi1PYlZRFdJME3w2DT5NggTDXPuT22Nfx_diFhbVTjIXJycMjiT21rPUGM2CqvDcJmi7277eJpoHBKVKMx2bPPLDratEEhMvIf2S-_sKyPrcOVhZu21FZONdtmylBDaIy7ztU7xSEBlAawgljUptpft22cGr7-Wn3SqatmcwuSk8NaCbe1QXgyH-TcvopReZyBhw0Sa-kcYx0T4TrvkFPVZor86CJQDNCHo2htaMkRC9iI-Tb4JUp7A7DHRp0zQAA4N5sy2aZGHknrTucH0PZjcFwdTG4miEs8QKCmZZ7GiLYiicg', '2023-03-26 09:05:34.731252+00');


--
-- Data for Name: asf_apis; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_apis" VALUES (1, 1, '获取控制台信息权限', 1, 2, '/api/asf/dash/getdetails', 'get', 0, '获取控制台信息权限', 1, 1, '2022-11-19 12:47:26.519666');
INSERT INTO "public"."asf_apis" VALUES (2, 3, '获取账户列表', 1, 2, '/api/asf/account/getlist', 'get', 0, '获取账户信息列表权限', 1, 1, '2022-11-19 12:47:26.529686');
INSERT INTO "public"."asf_apis" VALUES (3, 3, '添加账户', 1, 2, '/api/asf/account/create', 'post', 1, '添加账户信息权限', 1, 1, '2022-11-19 12:47:26.532654');
INSERT INTO "public"."asf_apis" VALUES (4, 3, '修改账户', 1, 2, '/api/asf/account/modify', 'post,put', 1, '修改账户信息权限', 1, 1, '2022-11-19 12:47:26.536592');
INSERT INTO "public"."asf_apis" VALUES (6, 3, '删除账户', 1, 2, '/api/asf/account/delete/[0-9]{1,100}', 'post,delete', 1, '删除账户信息权限', 1, 1, '2022-11-19 12:47:26.544519');
INSERT INTO "public"."asf_apis" VALUES (7, 3, '修改账户状态', 1, 2, '/api/asf/account/modifystatus', 'post,put', 1, '修改账户状态权限', 1, 1, '2022-11-19 12:47:26.548051');
INSERT INTO "public"."asf_apis" VALUES (8, 3, '修改账户密码', 1, 2, '/api/asf/account/resetpassword', 'post,put', 1, '修改账户密码权限', 1, 1, '2022-11-19 12:47:26.550358');
INSERT INTO "public"."asf_apis" VALUES (9, 3, '修改账户邮箱', 1, 2, '/api/asf/account/modifyemail', 'post,put', 1, '修改账户邮箱权限', 1, 1, '2022-11-19 12:47:26.552695');
INSERT INTO "public"."asf_apis" VALUES (10, 3, '修改账户邮箱', 1, 2, '/api/asf/account/modifytelphone', 'post,put', 1, '修改账户手机权限', 1, 1, '2022-11-19 12:47:26.554803');
INSERT INTO "public"."asf_apis" VALUES (11, 16, '修改账户头像', 1, 2, '/api/asf/account/modifyavatar', 'post,put', 1, '修改账户头像权限', 1, 1, '2022-11-19 12:47:26.556797');
INSERT INTO "public"."asf_apis" VALUES (12, 3, '账户分配角色', 1, 2, '/api/asf/account/assignrole', 'post,put', 1, '账户分配角色权限', 1, 1, '2022-11-19 12:47:26.558885');
INSERT INTO "public"."asf_apis" VALUES (13, 3, '账户分配部门', 1, 2, '/api/asf/account/assigndepartment', 'post,put', 1, '账户分配部门权限', 1, 1, '2022-11-19 12:47:26.561369');
INSERT INTO "public"."asf_apis" VALUES (14, 3, '账户分配岗位', 1, 2, '/api/asf/account/assignpost', 'post,put', 1, '账户分配岗位权限', 1, 1, '2022-11-19 12:47:26.56372');
INSERT INTO "public"."asf_apis" VALUES (15, 4, '获取权限列表', 1, 2, '/api/asf/permission/getlist', 'get', 0, '获取权限信息列表权限', 1, 1, '2022-11-19 12:47:26.56699');
INSERT INTO "public"."asf_apis" VALUES (16, 4, '获取权限列表', 1, 2, '/api/asf/permission/getlists', 'get', 0, '获取权限列表', 1, 1, '2022-11-19 12:47:26.569358');
INSERT INTO "public"."asf_apis" VALUES (17, 4, '分配权限给角色', 1, 2, '/api/asf/permission/assignpermission', 'post,put', 0, '获取角色列表', 1, 1, '2022-11-19 12:47:26.571597');
INSERT INTO "public"."asf_apis" VALUES (18, 4, '添加权限', 1, 2, '/api/asf/permission/create', 'post', 1, '添加权限信息权限', 1, 1, '2022-11-19 12:47:26.573343');
INSERT INTO "public"."asf_apis" VALUES (19, 4, '修改权限', 1, 2, '/api/asf/permission/modify', 'post,put', 1, '修改权限信息权限', 1, 1, '2022-11-19 12:47:26.575802');
INSERT INTO "public"."asf_apis" VALUES (21, 4, '删除权限', 1, 2, '/api/asf/permission/delete/[0-9]{1,100}', 'post,delete', 1, '删除权限信息权限', 1, 1, '2022-11-19 12:47:26.579501');
INSERT INTO "public"."asf_apis" VALUES (22, 5, '获取菜单列表', 1, 2, '/api/asf/menu/getlist', 'get', 0, '获取菜单信息列表权限', 1, 1, '2022-11-19 12:47:26.581112');
INSERT INTO "public"."asf_apis" VALUES (23, 5, '添加菜单', 1, 2, '/api/asf/menu/create', 'post', 1, '添加菜单信息权限', 1, 1, '2022-11-19 12:47:26.582622');
INSERT INTO "public"."asf_apis" VALUES (24, 5, '修改菜单', 1, 2, '/api/asf/menu/modify', 'post,put', 1, '修改菜单信息权限', 1, 1, '2022-11-19 12:47:26.584044');
INSERT INTO "public"."asf_apis" VALUES (25, 5, '获取菜单详情', 1, 2, '/api/asf/menu/details', 'get', 0, '获取菜单详情权限', 1, 1, '2022-11-19 12:47:26.585633');
INSERT INTO "public"."asf_apis" VALUES (26, 5, '删除菜单', 1, 2, '/api/asf/menu/delete/[0-9]{1,100}', 'post,delete', 1, '删除菜单信息权限', 1, 1, '2022-11-19 12:47:26.587365');
INSERT INTO "public"."asf_apis" VALUES (27, 5, '修改菜单是否隐藏', 1, 2, '/api/asf/menu/modifyhidden', 'post,put', 1, '修改菜单隐藏权限', 1, 1, '2022-11-19 12:47:26.589008');
INSERT INTO "public"."asf_apis" VALUES (28, 6, '获取api列表', 1, 2, '/api/asf/api/getlist', 'get', 0, '获取api信息列表权限', 1, 1, '2022-11-19 12:47:26.590745');
INSERT INTO "public"."asf_apis" VALUES (29, 6, '添加api', 1, 2, '/api/asf/api/create', 'post', 1, '添加api信息权限', 1, 1, '2022-11-19 12:47:26.59224');
INSERT INTO "public"."asf_apis" VALUES (30, 6, '修改api', 1, 2, '/api/asf/api/modify', 'post,put', 1, '修改api信息权限', 1, 1, '2022-11-19 12:47:26.593802');
INSERT INTO "public"."asf_apis" VALUES (31, 6, '获取api详情', 1, 2, '/api/asf/api/details', 'get', 0, '获取api详情权限', 1, 1, '2022-11-19 12:47:26.596137');
INSERT INTO "public"."asf_apis" VALUES (32, 6, '删除api', 1, 2, '/api/asf/api/delete/[0-9]{1,100}', 'post,delete', 1, '删除api信息权限', 1, 1, '2022-11-19 12:47:26.598283');
INSERT INTO "public"."asf_apis" VALUES (33, 6, '删除api', 1, 2, '/api/asf/api/batchdelete', 'post,delete', 1, '批量删除api信息权限', 1, 1, '2022-11-19 12:47:26.600456');
INSERT INTO "public"."asf_apis" VALUES (34, 6, '是否禁用api', 1, 2, '/api/asf/api/modifystatus', 'post,put', 1, '是否禁用api', 1, 1, '2022-11-19 12:47:26.602504');
INSERT INTO "public"."asf_apis" VALUES (35, 7, '获取角色列表', 1, 2, '/api/asf/role/getlist', 'get', 0, '获取角色信息列表权限', 1, 1, '2022-11-19 12:47:26.604584');
INSERT INTO "public"."asf_apis" VALUES (36, 7, '获取角色列表', 1, 2, '/api/asf/role/getlists', 'get', 0, '获取角色列表', 1, 1, '2022-11-19 12:47:26.606843');
INSERT INTO "public"."asf_apis" VALUES (37, 7, '添加角色', 1, 2, '/api/asf/role/create', 'post', 1, '添加角色信息权限', 1, 1, '2022-11-19 12:47:26.609008');
INSERT INTO "public"."asf_apis" VALUES (38, 7, '修改角色', 1, 2, '/api/asf/role/modify', 'post,put', 1, '修改角色信息权限', 1, 1, '2022-11-19 12:47:26.611466');
INSERT INTO "public"."asf_apis" VALUES (40, 7, '删除角色', 1, 2, '/api/asf/role/delete/[0-9]{1,100}', 'post,delete', 1, '删除角色信息权限', 1, 1, '2022-11-19 12:47:26.616539');
INSERT INTO "public"."asf_apis" VALUES (41, 7, '是否禁用角色', 1, 2, '/api/asf/role/modifystatus', 'post,put', 1, '是否禁用角色', 1, 1, '2022-11-19 12:47:26.619325');
INSERT INTO "public"."asf_apis" VALUES (42, 7, '角色分配权限', 1, 2, '/api/asf/role/assignpermission', 'post,put', 1, '角色分配权限', 1, 1, '2022-11-19 12:47:26.62199');
INSERT INTO "public"."asf_apis" VALUES (43, 9, '获取日志列表', 1, 2, '/api/asf/audio/getloglist', 'get', 0, '获取日志信息列表权限', 1, 1, '2022-11-19 12:47:26.624515');
INSERT INTO "public"."asf_apis" VALUES (44, 9, '删除日志', 1, 2, '/api/asf/audio/deletelog', 'post,delete', 1, '删除日志信息权限', 1, 1, '2022-11-19 12:47:26.627332');
INSERT INTO "public"."asf_apis" VALUES (45, 10, '获取调度任务列表', 1, 2, '/api/asf/task/getlist', 'get', 0, '获取调度任务信息列表权限', 1, 1, '2022-11-19 12:47:26.629922');
INSERT INTO "public"."asf_apis" VALUES (39, 389447011546656768, '获取角色详情', 1, 2, '/api/asf/role/details', 'get', 0, '获取角色详情权限', 1, 1, '2022-11-19 12:47:26.614018');
INSERT INTO "public"."asf_apis" VALUES (46, 10, '添加调度任务', 1, 2, '/api/asf/task/create', 'post', 1, '添加调度任务信息权限', 1, 1, '2022-11-19 12:47:26.632616');
INSERT INTO "public"."asf_apis" VALUES (47, 10, '修改调度任务', 1, 2, '/api/asf/task/modify', 'post,put', 1, '修改调度任务信息权限', 1, 1, '2022-11-19 12:47:26.635723');
INSERT INTO "public"."asf_apis" VALUES (48, 10, '获取调度任务详情', 1, 2, '/api/asf/task/details', 'get', 0, '获取调度任务详情权限', 1, 1, '2022-11-19 12:47:26.639155');
INSERT INTO "public"."asf_apis" VALUES (49, 10, '删除调度任务', 1, 2, '/api/asf/task/delete/[0-9]{1,100}', 'post,delete', 1, '删除调度任务信息权限', 1, 1, '2022-11-19 12:47:26.64181');
INSERT INTO "public"."asf_apis" VALUES (50, 11, '获取租户分页列表', 1, 2, '/api/asf/tenancy/getlist', 'get', 0, '获取租户信息分页列表权限', 1, 1, '2022-11-19 12:47:26.644292');
INSERT INTO "public"."asf_apis" VALUES (51, 11, '添加租户', 1, 2, '/api/asf/tenancy/create', 'post', 1, '添加租户信息权限', 1, 1, '2022-11-19 12:47:26.649803');
INSERT INTO "public"."asf_apis" VALUES (52, 11, '修改租户', 1, 2, '/api/asf/tenancy/modify', 'post,put', 1, '修改租户信息权限', 1, 1, '2022-11-19 12:47:26.657002');
INSERT INTO "public"."asf_apis" VALUES (53, 11, '获取租户详情', 1, 2, '/api/asf/tenancy/details', 'get', 0, '获取租户详情权限', 1, 1, '2022-11-19 12:47:26.660553');
INSERT INTO "public"."asf_apis" VALUES (54, 11, '删除租户', 1, 2, '/api/asf/tenancy/delete', 'post,put', 1, '删除租户信息权限', 1, 1, '2022-11-19 12:47:26.663431');
INSERT INTO "public"."asf_apis" VALUES (55, 12, '获取部门分页列表', 1, 2, '/api/asf/department/getlist', 'get', 0, '获取部门信息分页列表权限', 1, 1, '2022-11-19 12:47:26.666038');
INSERT INTO "public"."asf_apis" VALUES (56, 12, '修改部门状态', 1, 2, '/api/asf/department/modifystatus', 'post,put', 0, '修改部门状态', 1, 1, '2022-11-19 12:47:26.668846');
INSERT INTO "public"."asf_apis" VALUES (57, 12, '删除部门', 1, 2, '/api/asf/department/delete/[0-9]{1,100}', 'post,delete', 0, '修改部门状态', 1, 1, '2022-11-19 12:47:26.67177');
INSERT INTO "public"."asf_apis" VALUES (58, 12, '获取部门列表', 1, 2, '/api/asf/department/getlists', 'get', 0, '获取部门信息列表权限', 1, 1, '2022-11-19 12:47:26.674974');
INSERT INTO "public"."asf_apis" VALUES (59, 12, '添加部门', 1, 2, '/api/asf/department/create', 'post', 1, '添加部门信息权限', 1, 1, '2022-11-19 12:47:26.677376');
INSERT INTO "public"."asf_apis" VALUES (60, 12, '修改部门', 1, 2, '/api/asf/department/modify', 'post,put', 1, '修改部门信息权限', 1, 1, '2022-11-19 12:47:26.680253');
INSERT INTO "public"."asf_apis" VALUES (62, 12, '分配部门角色', 1, 2, '/api/asf/department/assign', 'post,put', 1, '分配部门角色', 1, 1, '2022-11-19 12:47:26.684949');
INSERT INTO "public"."asf_apis" VALUES (63, 13, '获取岗位分页列表', 1, 2, '/api/asf/post/getlist', 'get', 0, '获取岗位信息分页列表权限', 1, 1, '2022-11-19 12:47:26.687385');
INSERT INTO "public"."asf_apis" VALUES (64, 13, '获取岗位列表', 1, 2, '/api/asf/post/getlists', 'get', 0, '获取岗位信息列表权限', 1, 1, '2022-11-19 12:47:26.689911');
INSERT INTO "public"."asf_apis" VALUES (65, 13, '添加岗位', 1, 2, '/api/asf/post/create', 'post', 1, '添加岗位信息权限', 1, 1, '2022-11-19 12:47:26.692814');
INSERT INTO "public"."asf_apis" VALUES (66, 13, '修改岗位', 1, 2, '/api/asf/post/modify', 'post,put', 1, '修改岗位信息权限', 1, 1, '2022-11-19 12:47:26.695277');
INSERT INTO "public"."asf_apis" VALUES (67, 13, '获取岗位详情', 1, 2, '/api/asf/post/details', 'get', 0, '获取岗位详情权限', 1, 1, '2022-11-19 12:47:26.698024');
INSERT INTO "public"."asf_apis" VALUES (68, 13, '删除岗位', 1, 2, '/api/asf/post/delete/[0-9]{1,100}', 'post,delete', 1, '删除岗位信息权限', 1, 1, '2022-11-19 12:47:26.700995');
INSERT INTO "public"."asf_apis" VALUES (69, 14, '获取多语言分页列表', 1, 2, '/api/asf/translate/getlist', 'get', 0, '获取多语言信息列表权限', 1, 1, '2022-11-19 12:47:26.70324');
INSERT INTO "public"."asf_apis" VALUES (70, 16, '获取多语言所有列表', 1, 1, '/api/asf/translate/getlists', 'get', 0, '获取多语言信息列表权限', 1, 1, '2022-11-19 12:47:26.7052');
INSERT INTO "public"."asf_apis" VALUES (71, 14, '添加多语言', 1, 2, '/api/asf/translate/create', 'post', 1, '添加多语言信息权限', 1, 1, '2022-11-19 12:47:26.707425');
INSERT INTO "public"."asf_apis" VALUES (72, 14, '修改多语言', 1, 2, '/api/asf/translate/modify', 'post,put', 1, '修改多语言信息权限', 1, 1, '2022-11-19 12:47:26.70971');
INSERT INTO "public"."asf_apis" VALUES (73, 14, '获取多语言详情', 1, 2, '/api/asf/translate/details', 'get', 0, '获取多语言详情权限', 1, 1, '2022-11-19 12:47:26.711895');
INSERT INTO "public"."asf_apis" VALUES (74, 14, '删除多语言', 1, 2, '/api/asf/translate/delete/[0-9]{1,100}', 'post,delete', 1, '删除多语言信息权限', 1, 1, '2022-11-19 12:47:26.714418');
INSERT INTO "public"."asf_apis" VALUES (75, 15, '获取字典分页列表', 1, 2, '/api/asf/dictionary/getlist', 'get', 0, '获取字典信息列表权限', 1, 1, '2022-11-19 12:47:26.716721');
INSERT INTO "public"."asf_apis" VALUES (76, 15, '获取字典所有列表', 1, 2, '/api/asf/dictionary/getlists', 'get', 0, '获取字典信息列表权限', 1, 1, '2022-11-19 12:47:26.718912');
INSERT INTO "public"."asf_apis" VALUES (77, 15, '添加字典', 1, 2, '/api/asf/dictionary/create', 'post', 1, '添加字典信息权限', 1, 1, '2022-11-19 12:47:26.721771');
INSERT INTO "public"."asf_apis" VALUES (78, 15, '修改字典', 1, 2, '/api/asf/dictionary/modify', 'post,put', 1, '修改字典信息权限', 1, 1, '2022-11-19 12:47:26.724233');
INSERT INTO "public"."asf_apis" VALUES (79, 15, '获取字典详情', 1, 2, '/api/asf/dictionary/details', 'get', 0, '获取字典详情权限', 1, 1, '2022-11-19 12:47:26.726688');
INSERT INTO "public"."asf_apis" VALUES (80, 15, '删除多字典', 1, 2, '/api/asf/dictionary/delete/[0-9]{1,100}', 'post,delete', 1, '删除字典信息权限', 1, 1, '2022-11-19 12:47:26.729476');
INSERT INTO "public"."asf_apis" VALUES (81, 16, '登录', 1, 1, '/api/asf/authorise/login', 'post', 0, '登录账户权限', 1, 1, '2022-11-19 12:47:26.73191');
INSERT INTO "public"."asf_apis" VALUES (82, 16, '登出', 1, 1, '/api/asf/authorise/logout', 'post', 0, '登出账户权限', 1, 1, '2022-11-19 12:47:26.73461');
INSERT INTO "public"."asf_apis" VALUES (83, 16, '获取登录账户信息', 1, 1, '/api/asf/account/accountinfo', 'get', 0, '用户信息权限', 1, 1, '2022-11-19 12:47:26.739072');
INSERT INTO "public"."asf_apis" VALUES (84, 16, '获取租户列表集合', 1, 1, '/api/asf/tenancy/getlists', 'get', 0, '获取租户列表集合', 1, 1, '2022-11-19 12:47:26.742038');
INSERT INTO "public"."asf_apis" VALUES (85, 16, '上传文件', 1, 1, '/api/asf/upload/index', 'post,put', 0, '上传文件', 1, 1, '2022-11-19 12:47:26.744994');
INSERT INTO "public"."asf_apis" VALUES (61, 389447780190613504, '获取部门详情', 1, 2, '/api/asf/department/details', 'get', 0, '获取部门详情权限', 1, 1, '2022-11-19 12:47:26.682653');
INSERT INTO "public"."asf_apis" VALUES (5, 389431849661984768, '获取账户详情', 1, 2, '/api/asf/account/details', 'get', 0, '获取账户信息详情权限', 1, 1, '2022-11-19 12:47:26.541004');
INSERT INTO "public"."asf_apis" VALUES (20, 394410371264667648, '获取权限详情', 1, 2, '/api/asf/permission/details', 'get', 0, '获取权限详情权限', 1, 1, '2022-11-19 12:47:26.577645');


--
-- Data for Name: asf_department; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_department" VALUES (1, 0, 1, '开发部', 1, 0, '2022-11-19 12:47:26.79596');
INSERT INTO "public"."asf_department" VALUES (2, 1, 1, '.net 组', 1, 0, '2022-11-19 12:47:26.800509');
INSERT INTO "public"."asf_department" VALUES (3, 1, 1, 'java 组', 1, 0, '2022-11-19 12:47:26.803381');
INSERT INTO "public"."asf_department" VALUES (4, 1, 1, 'app 组', 1, 0, '2022-11-19 12:47:26.80633');
INSERT INTO "public"."asf_department" VALUES (5, 1, 1, 'php 组', 1, 0, '2022-11-19 12:47:26.808674');
INSERT INTO "public"."asf_department" VALUES (6, 1, 1, '前端 组', 1, 0, '2022-11-19 12:47:26.810937');
INSERT INTO "public"."asf_department" VALUES (7, 1, 1, 'ui 组', 1, 0, '2022-11-19 12:47:26.813386');
INSERT INTO "public"."asf_department" VALUES (8, 1, 1, '运维 组', 1, 0, '2022-11-19 12:47:26.8161');
INSERT INTO "public"."asf_department" VALUES (9, 0, 1, '人事部', 1, 0, '2022-11-19 12:47:26.819112');
INSERT INTO "public"."asf_department" VALUES (10, 9, 1, '人事一组', 1, 0, '2022-11-19 12:47:26.821793');
INSERT INTO "public"."asf_department" VALUES (11, 9, 1, '人事二组', 1, 0, '2022-11-19 12:47:26.82381');
INSERT INTO "public"."asf_department" VALUES (12, 9, 1, '人事三组', 1, 0, '2022-11-19 12:47:26.825412');
INSERT INTO "public"."asf_department" VALUES (13, 0, 1, '财务部', 1, 0, '2022-11-19 12:47:26.827302');
INSERT INTO "public"."asf_department" VALUES (14, 13, 1, '财务一组', 1, 0, '2022-11-19 12:47:26.829308');
INSERT INTO "public"."asf_department" VALUES (15, 13, 1, '财务二组', 1, 0, '2022-11-19 12:47:26.8315');
INSERT INTO "public"."asf_department" VALUES (16, 13, 1, '财务三组', 1, 0, '2022-11-19 12:47:26.833782');
INSERT INTO "public"."asf_department" VALUES (17, 0, 1, '运营部', 1, 0, '2022-11-19 12:47:26.835831');
INSERT INTO "public"."asf_department" VALUES (18, 17, 1, '运营一组', 1, 0, '2022-11-19 12:47:26.837566');
INSERT INTO "public"."asf_department" VALUES (19, 17, 1, '运营二组', 1, 0, '2022-11-19 12:47:26.839896');
INSERT INTO "public"."asf_department" VALUES (20, 17, 1, '运营三组', 1, 0, '2022-11-19 12:47:26.842236');
INSERT INTO "public"."asf_department" VALUES (21, 0, 2, '人事部', 1, 0, '2022-11-19 12:47:26.84428');
INSERT INTO "public"."asf_department" VALUES (22, 21, 2, '人事一组', 1, 0, '2022-11-19 12:47:26.846168');
INSERT INTO "public"."asf_department" VALUES (23, 21, 2, '人事二组', 1, 0, '2022-11-19 12:47:26.848038');
INSERT INTO "public"."asf_department" VALUES (24, 21, 2, '人事三组', 1, 0, '2022-11-19 12:47:26.850342');
INSERT INTO "public"."asf_department" VALUES (25, 0, 2, '财务部', 1, 0, '2022-11-19 12:47:26.852458');
INSERT INTO "public"."asf_department" VALUES (26, 25, 2, '财务一组', 1, 0, '2022-11-19 12:47:26.855305');
INSERT INTO "public"."asf_department" VALUES (27, 25, 2, '财务二组', 1, 0, '2022-11-19 12:47:26.857218');
INSERT INTO "public"."asf_department" VALUES (28, 25, 2, '财务三组', 1, 0, '2022-11-19 12:47:26.85922');
INSERT INTO "public"."asf_department" VALUES (29, 0, 2, '运营部', 1, 0, '2022-11-19 12:47:26.860985');
INSERT INTO "public"."asf_department" VALUES (30, 29, 2, '运营一组', 1, 0, '2022-11-19 12:47:26.862904');
INSERT INTO "public"."asf_department" VALUES (31, 29, 2, '运营二组', 1, 0, '2022-11-19 12:47:26.864783');
INSERT INTO "public"."asf_department" VALUES (32, 29, 2, '运营三组', 1, 0, '2022-11-19 12:47:26.86658');


--
-- Data for Name: asf_department_role; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_department_role" VALUES (1, 3, 1, '2022-11-19 12:47:26.875779');
INSERT INTO "public"."asf_department_role" VALUES (2, 1, 2, '2022-11-19 12:47:26.882214');
INSERT INTO "public"."asf_department_role" VALUES (3, 1, 3, '2022-11-19 12:47:26.88431');
INSERT INTO "public"."asf_department_role" VALUES (4, 1, 4, '2022-11-19 12:47:26.88658');
INSERT INTO "public"."asf_department_role" VALUES (5, 1, 5, '2022-11-19 12:47:26.889463');
INSERT INTO "public"."asf_department_role" VALUES (6, 1, 6, '2022-11-19 12:47:26.892382');
INSERT INTO "public"."asf_department_role" VALUES (7, 1, 7, '2022-11-19 12:47:26.8948');
INSERT INTO "public"."asf_department_role" VALUES (8, 2, 8, '2022-11-19 12:47:26.896745');
INSERT INTO "public"."asf_department_role" VALUES (9, 3, 9, '2022-11-19 12:47:26.899289');
INSERT INTO "public"."asf_department_role" VALUES (10, 3, 10, '2022-11-19 12:47:26.901238');
INSERT INTO "public"."asf_department_role" VALUES (11, 3, 11, '2022-11-19 12:47:26.903568');
INSERT INTO "public"."asf_department_role" VALUES (12, 3, 12, '2022-11-19 12:47:26.906158');
INSERT INTO "public"."asf_department_role" VALUES (13, 3, 13, '2022-11-19 12:47:26.908331');
INSERT INTO "public"."asf_department_role" VALUES (14, 3, 14, '2022-11-19 12:47:26.910995');
INSERT INTO "public"."asf_department_role" VALUES (15, 3, 15, '2022-11-19 12:47:26.913333');
INSERT INTO "public"."asf_department_role" VALUES (16, 3, 16, '2022-11-19 12:47:26.915206');
INSERT INTO "public"."asf_department_role" VALUES (17, 3, 17, '2022-11-19 12:47:26.918617');


--
-- Data for Name: asf_dictionary; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Data for Name: asf_loginfos; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Data for Name: asf_permission; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_permission" VALUES (1, '/', 0, '控制台', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.468765');
INSERT INTO "public"."asf_permission" VALUES (2, '/control', 0, '控制面板权限', 1, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.470818');
INSERT INTO "public"."asf_permission" VALUES (3, '/control/account', 2, '账户管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.473978');
INSERT INTO "public"."asf_permission" VALUES (4, '/control/permission', 2, '权限管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.476693');
INSERT INTO "public"."asf_permission" VALUES (5, '/control/menu', 2, '菜单管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.478629');
INSERT INTO "public"."asf_permission" VALUES (6, '/control/authapi', 2, '授权api管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.480858');
INSERT INTO "public"."asf_permission" VALUES (7, '/control/role', 2, '角色管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.482765');
INSERT INTO "public"."asf_permission" VALUES (8, '/control/audio', 2, '审计管理权限', 1, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.48457');
INSERT INTO "public"."asf_permission" VALUES (9, '/control/audio/getlog', 8, '日志权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.486484');
INSERT INTO "public"."asf_permission" VALUES (10, '/control/scheduledtask', 2, '调度任务权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.488216');
INSERT INTO "public"."asf_permission" VALUES (11, '/control/tenancy', 2, '租户管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.490459');
INSERT INTO "public"."asf_permission" VALUES (12, '/control/department', 2, '部门管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.492466');
INSERT INTO "public"."asf_permission" VALUES (13, '/control/post', 2, '岗位管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.495717');
INSERT INTO "public"."asf_permission" VALUES (14, '/control/translate', 2, '多语言管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.500302');
INSERT INTO "public"."asf_permission" VALUES (15, '/control/dictionary', 2, '字典管理权限', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.505062');
INSERT INTO "public"."asf_permission" VALUES (16, '/control/openapi', 0, '公共权限', 3, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.509253');
INSERT INTO "public"."asf_permission" VALUES (17, '/components', 0, '组件示例', 2, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.513102');
INSERT INTO "public"."asf_permission" VALUES (331075142022815744, '/user/center', 0, '个人中心', 3, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.516298');
INSERT INTO "public"."asf_permission" VALUES (389431849661984768, '/control/account/details', 3, '账户详情权限', 3, 1, '账户详情权限', 0, 1, 1, '2023-03-11 15:03:08.299071');
INSERT INTO "public"."asf_permission" VALUES (389447011546656768, '/control/role/details', 7, '角色详情权限', 3, 1, '角色详情权限', 0, 1, 1, '2023-03-11 16:03:23.147601');
INSERT INTO "public"."asf_permission" VALUES (389447780190613504, '/control/department/details', 12, '部门详情权限', 3, 1, '部门详情权限', 0, 1, 1, '2023-03-11 16:06:26.409813');
INSERT INTO "public"."asf_permission" VALUES (394410371264667648, '/control/permission/details', 4, '权限详情', 3, 0, '权限详情', 0, 1, 1, '2023-03-25 08:46:00.326874');


--
-- Data for Name: asf_permission_menu; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_permission_menu" VALUES (1, 1, '控制台', '控制台菜单', 'icon-dash_board', 0, '/', NULL, NULL, '控制台菜单', NULL, 1, 1, '2022-11-19 12:47:26.74763');
INSERT INTO "public"."asf_permission_menu" VALUES (2, 2, '控制面板', '控制面板菜单', 'icon-dash_board', 0, '/control', NULL, NULL, '控制面板菜单', NULL, 1, 1, '2022-11-19 12:47:26.752622');
INSERT INTO "public"."asf_permission_menu" VALUES (3, 3, '账户管理', '账户管理', 'icon--proxyaccount', 0, '/control/account', NULL, NULL, '账户管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.754557');
INSERT INTO "public"."asf_permission_menu" VALUES (4, 4, '权限管理', '权限管理', 'icon-icon-authority', 0, '/control/permission', NULL, NULL, '权限管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.757387');
INSERT INTO "public"."asf_permission_menu" VALUES (5, 5, '菜单管理', '菜单管理', 'icon-caidan', 0, '/control/menu', NULL, NULL, '菜单管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.760331');
INSERT INTO "public"."asf_permission_menu" VALUES (6, 6, '授权api管理', 'api管理', 'icon-api', 0, '/control/authapi', NULL, NULL, '授权api菜单', NULL, 1, 1, '2022-11-19 12:47:26.762817');
INSERT INTO "public"."asf_permission_menu" VALUES (7, 7, '角色管理', '角色管理', 'icon-role', 0, '/control/role', NULL, NULL, '角色管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.765302');
INSERT INTO "public"."asf_permission_menu" VALUES (8, 8, '审计管理', '审计管理', 'icon-audio', 0, '/audio', NULL, NULL, '审计管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.768516');
INSERT INTO "public"."asf_permission_menu" VALUES (9, 9, '日志管理', '日志管理', 'icon-errorcorrection_default', 0, '/control/audio/getlog', NULL, NULL, '日志管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.771202');
INSERT INTO "public"."asf_permission_menu" VALUES (10, 10, '调度任务', '调度任务', 'icon-schedule_date', 1, '/control/scheduled_task', NULL, NULL, '调度任务菜单', NULL, 1, 1, '2022-11-19 12:47:26.773561');
INSERT INTO "public"."asf_permission_menu" VALUES (11, 11, '租户管理', '租户管理', 'icon-tenancy', 0, '/control/tenancy', NULL, NULL, '租户管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.776489');
INSERT INTO "public"."asf_permission_menu" VALUES (12, 12, '部门管理', '部门管理', 'icon-bumen', 0, '/control/department', NULL, NULL, '部门管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.780295');
INSERT INTO "public"."asf_permission_menu" VALUES (13, 13, '岗位管理', '岗位管理', 'icon-gangwei', 0, '/control/post', NULL, NULL, '岗位管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.782922');
INSERT INTO "public"."asf_permission_menu" VALUES (14, 14, '多语言管理', '多语言管理', 'icon-EA', 0, '/control/translate', NULL, NULL, '多语言管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.785668');
INSERT INTO "public"."asf_permission_menu" VALUES (15, 15, '字典管理', '字典管理', 'icon-EA', 0, '/control/dictionary', NULL, NULL, '多语言管理菜单', NULL, 1, 1, '2022-11-19 12:47:26.789662');
INSERT INTO "public"."asf_permission_menu" VALUES (16, 17, '组件示例', '组件示例', 'icon-EA', 0, '/components', NULL, NULL, '组件示例', NULL, 1, 1, '2022-11-19 12:47:26.79285');


--
-- Data for Name: asf_post; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_post" VALUES (1, 1, 'java 开发', 0, 0, NULL, 1, '2022-11-19 12:47:26.447825');
INSERT INTO "public"."asf_post" VALUES (2, 1, '运维', 0, 0, NULL, 1, '2022-11-19 12:47:26.449606');
INSERT INTO "public"."asf_post" VALUES (3, 1, '.net 开发', 0, 0, NULL, 1, '2022-11-19 12:47:26.450925');
INSERT INTO "public"."asf_post" VALUES (4, 1, 'android 开发', 0, 0, NULL, 1, '2022-11-19 12:47:26.452202');
INSERT INTO "public"."asf_post" VALUES (5, 1, '前端 开发', 0, 0, NULL, 1, '2022-11-19 12:47:26.45377');
INSERT INTO "public"."asf_post" VALUES (6, 1, 'ios 开发', 0, 0, NULL, 1, '2022-11-19 12:47:26.455126');
INSERT INTO "public"."asf_post" VALUES (7, 1, '员工', 0, 0, NULL, 1, '2022-11-19 12:47:26.456418');
INSERT INTO "public"."asf_post" VALUES (8, 1, '组长', 0, 0, NULL, 1, '2022-11-19 12:47:26.457774');
INSERT INTO "public"."asf_post" VALUES (9, 1, '经理', 0, 0, NULL, 1, '2022-11-19 12:47:26.459204');
INSERT INTO "public"."asf_post" VALUES (10, 1, '主管', 0, 0, NULL, 1, '2022-11-19 12:47:26.460432');
INSERT INTO "public"."asf_post" VALUES (11, 2, '员工', 0, 0, NULL, 1, '2022-11-19 12:47:26.462337');
INSERT INTO "public"."asf_post" VALUES (12, 2, '组长', 0, 0, NULL, 1, '2022-11-19 12:47:26.463639');
INSERT INTO "public"."asf_post" VALUES (13, 2, '经理', 0, 0, NULL, 1, '2022-11-19 12:47:26.464989');
INSERT INTO "public"."asf_post" VALUES (14, 2, '主管', 0, 0, NULL, 1, '2022-11-19 12:47:26.466814');


--
-- Data for Name: asf_role; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_role" VALUES (2, 1, 'admin', '普通管理员，拥有部分权限', 1, 1, '2022-11-19 12:47:26.871347');
INSERT INTO "public"."asf_role" VALUES (3, 1, 'user', '总部 普通员工, 拥有普通权限', 1, 1, '2022-11-19 12:47:26.873376');
INSERT INTO "public"."asf_role" VALUES (1, 1, 'superadmin', '总超级管理员拥有下属租户所有权限', 1, 1, '2022-11-19 12:47:26.868486');


--
-- Data for Name: asf_role_permission; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_role_permission" VALUES (2, 2, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (3, 3, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (4, 4, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (5, 5, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (6, 6, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (7, 7, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (8, 8, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (9, 9, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (10, 10, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (11, 11, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (12, 12, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (13, 13, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (14, 15, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (15, 16, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (1, 1, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (16, 17, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (17, 331075142022815744, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (18, 389431849661984768, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (19, 389447011546656768, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (20, 389447780190613504, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (21, 394410371264667648, 1, '2023-03-25 08:57:05.216912');
INSERT INTO "public"."asf_role_permission" VALUES (22, 1, 2, '2022-11-19 12:47:26.970098');
INSERT INTO "public"."asf_role_permission" VALUES (23, 4, 2, '2022-11-19 12:47:26.975585');
INSERT INTO "public"."asf_role_permission" VALUES (24, 5, 2, '2022-11-19 12:47:26.979874');
INSERT INTO "public"."asf_role_permission" VALUES (25, 6, 2, '2022-11-19 12:47:26.981616');
INSERT INTO "public"."asf_role_permission" VALUES (26, 8, 2, '2022-11-19 12:47:26.983295');
INSERT INTO "public"."asf_role_permission" VALUES (27, 9, 2, '2022-11-19 12:47:26.985562');
INSERT INTO "public"."asf_role_permission" VALUES (28, 14, 2, '2022-11-19 12:47:26.987631');
INSERT INTO "public"."asf_role_permission" VALUES (29, 15, 2, '2022-11-19 12:47:26.989538');
INSERT INTO "public"."asf_role_permission" VALUES (30, 16, 2, '2022-11-19 12:47:26.992033');
INSERT INTO "public"."asf_role_permission" VALUES (31, 17, 2, '2022-11-19 12:47:26.993854');
INSERT INTO "public"."asf_role_permission" VALUES (32, 331075142022815744, 2, '2022-11-19 12:47:26.995879');
INSERT INTO "public"."asf_role_permission" VALUES (33, 2, 2, '2022-11-19 12:47:26.972609');
INSERT INTO "public"."asf_role_permission" VALUES (34, 16, 3, '2022-11-19 12:47:26.99912');
INSERT INTO "public"."asf_role_permission" VALUES (35, 17, 3, '2022-11-19 12:47:27.001088');
INSERT INTO "public"."asf_role_permission" VALUES (36, 331075142022815744, 3, '2022-11-19 12:47:27.00308');
INSERT INTO "public"."asf_role_permission" VALUES (37, 1, 3, '2022-11-19 12:47:26.997474');


--
-- Data for Name: asf_scheduled_task; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Data for Name: asf_security_token; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Data for Name: asf_tenancy; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_tenancy" VALUES (1, '总部集团', 0, 0, 1, 1, 0, '2022-11-19 12:47:26.43899');
INSERT INTO "public"."asf_tenancy" VALUES (2, '公司A', 0, 0, 1, 1, 0, '2022-11-19 12:47:26.446391');


--
-- Data for Name: asf_translate; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Name: asf_account_post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_account_post_id_seq"', 4, true);


--
-- Name: asf_account_post_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_account_post_id_seq1"', 1, false);


--
-- Name: asf_account_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_account_role_id_seq"', 1, true);


--
-- Name: asf_account_role_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_account_role_id_seq1"', 1, false);


--
-- Name: asf_accounts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_accounts_id_seq"', 1, false);


--
-- Name: asf_accounts_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_accounts_id_seq1"', 1, false);


--
-- Name: asf_apis_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_apis_id_seq"', 1, false);


--
-- Name: asf_apis_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_apis_id_seq1"', 1, false);


--
-- Name: asf_department_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_department_id_seq"', 1, false);


--
-- Name: asf_department_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_department_id_seq1"', 1, false);


--
-- Name: asf_department_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_department_role_id_seq"', 17, true);


--
-- Name: asf_department_role_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_department_role_id_seq1"', 1, false);


--
-- Name: asf_dictionary_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_dictionary_id_seq"', 1, false);


--
-- Name: asf_dictionary_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_dictionary_id_seq1"', 1, false);


--
-- Name: asf_loginfos_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_loginfos_id_seq"', 1, false);


--
-- Name: asf_loginfos_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_loginfos_id_seq1"', 1, false);


--
-- Name: asf_permission_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_permission_id_seq"', 1, false);


--
-- Name: asf_permission_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_permission_id_seq1"', 1, false);


--
-- Name: asf_permission_menu_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_permission_menu_id_seq"', 1, false);


--
-- Name: asf_permission_menu_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_permission_menu_id_seq1"', 1, false);


--
-- Name: asf_post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_post_id_seq"', 1, false);


--
-- Name: asf_post_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_post_id_seq1"', 1, false);


--
-- Name: asf_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_role_id_seq"', 1, false);


--
-- Name: asf_role_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_role_id_seq1"', 1, false);


--
-- Name: asf_role_permission_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_role_permission_id_seq"', 37, true);


--
-- Name: asf_role_permission_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_role_permission_id_seq1"', 37, true);


--
-- Name: asf_scheduled_task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_scheduled_task_id_seq"', 1, false);


--
-- Name: asf_scheduled_task_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_scheduled_task_id_seq1"', 1, false);


--
-- Name: asf_security_token_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_security_token_id_seq"', 1, true);


--
-- Name: asf_security_token_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_security_token_id_seq1"',1, true);


--
-- Name: asf_tenancy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_tenancy_id_seq"', 1, false);


--
-- Name: asf_tenancy_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_tenancy_id_seq1"', 1, false);


--
-- Name: asf_translate_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_translate_id_seq"', 1, false);


--
-- Name: asf_translate_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_translate_id_seq1"', 1, false);


--
-- Name: asf_account_post PK_asf_account_post; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_post"
    ADD CONSTRAINT "PK_asf_account_post" PRIMARY KEY ("id");


--
-- Name: asf_account_role PK_asf_account_role; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_role"
    ADD CONSTRAINT "PK_asf_account_role" PRIMARY KEY ("id");


--
-- Name: asf_accounts PK_asf_accounts; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_accounts"
    ADD CONSTRAINT "PK_asf_accounts" PRIMARY KEY ("id");


--
-- Name: asf_apis PK_asf_apis; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_apis"
    ADD CONSTRAINT "PK_asf_apis" PRIMARY KEY ("id");


--
-- Name: asf_department PK_asf_department; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_department"
    ADD CONSTRAINT "PK_asf_department" PRIMARY KEY ("id");


--
-- Name: asf_department_role PK_asf_department_role; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_department_role"
    ADD CONSTRAINT "PK_asf_department_role" PRIMARY KEY ("id");


--
-- Name: asf_dictionary PK_asf_dictionary; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_dictionary"
    ADD CONSTRAINT "PK_asf_dictionary" PRIMARY KEY ("id");


--
-- Name: asf_loginfos PK_asf_loginfos; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_loginfos"
    ADD CONSTRAINT "PK_asf_loginfos" PRIMARY KEY ("id");


--
-- Name: asf_permission PK_asf_permission; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_permission"
    ADD CONSTRAINT "PK_asf_permission" PRIMARY KEY ("id");


--
-- Name: asf_permission_menu PK_asf_permission_menu; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_permission_menu"
    ADD CONSTRAINT "PK_asf_permission_menu" PRIMARY KEY ("id");


--
-- Name: asf_post PK_asf_post; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_post"
    ADD CONSTRAINT "PK_asf_post" PRIMARY KEY ("id");


--
-- Name: asf_role PK_asf_role; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_role"
    ADD CONSTRAINT "PK_asf_role" PRIMARY KEY ("id");


--
-- Name: asf_role_permission PK_asf_role_permission; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_role_permission"
    ADD CONSTRAINT "PK_asf_role_permission" PRIMARY KEY ("id");


--
-- Name: asf_scheduled_task PK_asf_scheduled_task; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_scheduled_task"
    ADD CONSTRAINT "PK_asf_scheduled_task" PRIMARY KEY ("id");


--
-- Name: asf_security_token PK_asf_security_token; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_security_token"
    ADD CONSTRAINT "PK_asf_security_token" PRIMARY KEY ("id");


--
-- Name: asf_tenancy PK_asf_tenancy; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_tenancy"
    ADD CONSTRAINT "PK_asf_tenancy" PRIMARY KEY ("id");


--
-- Name: asf_translate PK_asf_translate; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_translate"
    ADD CONSTRAINT "PK_asf_translate" PRIMARY KEY ("id");


--
-- Name: IX_asf_account_post_account_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_account_post_account_id" ON "public"."asf_account_post" USING "btree" ("account_id");


--
-- Name: IX_asf_account_post_post_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_account_post_post_id" ON "public"."asf_account_post" USING "btree" ("post_id");


--
-- Name: IX_asf_account_role_account_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_account_role_account_id" ON "public"."asf_account_role" USING "btree" ("account_id");


--
-- Name: IX_asf_account_role_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_account_role_role_id" ON "public"."asf_account_role" USING "btree" ("role_id");


--
-- Name: IX_asf_accounts_department_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_accounts_department_id" ON "public"."asf_accounts" USING "btree" ("department_id");


--
-- Name: IX_asf_accounts_email; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_accounts_email" ON "public"."asf_accounts" USING "btree" ("email");


--
-- Name: IX_asf_accounts_tenancy_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_accounts_tenancy_id" ON "public"."asf_accounts" USING "btree" ("tenancy_id");


--
-- Name: IX_asf_accounts_username; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_accounts_username" ON "public"."asf_accounts" USING "btree" ("username");


--
-- Name: IX_asf_apis_name; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_apis_name" ON "public"."asf_apis" USING "btree" ("name");


--
-- Name: IX_asf_apis_path; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_apis_path" ON "public"."asf_apis" USING "btree" ("path");


--
-- Name: IX_asf_apis_permission_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_apis_permission_id" ON "public"."asf_apis" USING "btree" ("permission_id");


--
-- Name: IX_asf_department_role_department_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_department_role_department_id" ON "public"."asf_department_role" USING "btree" ("department_id");


--
-- Name: IX_asf_department_role_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_department_role_role_id" ON "public"."asf_department_role" USING "btree" ("role_id");


--
-- Name: IX_asf_dictionary_key; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_dictionary_key" ON "public"."asf_dictionary" USING "btree" ("key");


--
-- Name: IX_asf_permission_menu_menu_url; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_asf_permission_menu_menu_url" ON "public"."asf_permission_menu" USING "btree" ("menu_url");


--
-- Name: IX_asf_permission_menu_permission_id; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_asf_permission_menu_permission_id" ON "public"."asf_permission_menu" USING "btree" ("permission_id");


--
-- Name: IX_asf_permission_menu_title; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_asf_permission_menu_title" ON "public"."asf_permission_menu" USING "btree" ("title");


--
-- Name: IX_asf_permission_name; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_permission_name" ON "public"."asf_permission" USING "btree" ("name");


--
-- Name: IX_asf_role_permission_permission_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_role_permission_permission_id" ON "public"."asf_role_permission" USING "btree" ("permission_id");


--
-- Name: IX_asf_role_permission_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_asf_role_permission_role_id" ON "public"."asf_role_permission" USING "btree" ("role_id");


--
-- Name: IX_asf_translate_value; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_asf_translate_value" ON "public"."asf_translate" USING "btree" ("value");


--
-- Name: asf_accounts FK_asf_accounts_asf_department_department_id; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_accounts"
    ADD CONSTRAINT "FK_asf_accounts_asf_department_department_id" FOREIGN KEY ("department_id") REFERENCES "public"."asf_department"("id");


--
-- Name: asf_accounts FK_asf_accounts_asf_tenancy_tenancy_id; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_accounts"
    ADD CONSTRAINT "FK_asf_accounts_asf_tenancy_tenancy_id" FOREIGN KEY ("tenancy_id") REFERENCES "public"."asf_tenancy"("id");


--
-- Name: asf_permission_menu FK_asf_permission_menu_asf_permission_permission_id; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_permission_menu"
    ADD CONSTRAINT "FK_asf_permission_menu_asf_permission_permission_id" FOREIGN KEY ("permission_id") REFERENCES "public"."asf_permission"("id") ON DELETE CASCADE;


--
-- Name: asf_account_role account_account_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_role"
    ADD CONSTRAINT "account_account_id_foreign" FOREIGN KEY ("account_id") REFERENCES "public"."asf_accounts"("id") ON DELETE CASCADE;


--
-- Name: asf_account_post account_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_post"
    ADD CONSTRAINT "account_id_foreign" FOREIGN KEY ("account_id") REFERENCES "public"."asf_accounts"("id") ON DELETE CASCADE;


--
-- Name: asf_account_role account_role_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_role"
    ADD CONSTRAINT "account_role_id_foreign" FOREIGN KEY ("role_id") REFERENCES "public"."asf_role"("id") ON DELETE CASCADE;


--
-- Name: asf_apis api_permission_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_apis"
    ADD CONSTRAINT "api_permission_id_foreign" FOREIGN KEY ("permission_id") REFERENCES "public"."asf_permission"("id");


--
-- Name: asf_department_role dept_department_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_department_role"
    ADD CONSTRAINT "dept_department_id_foreign" FOREIGN KEY ("department_id") REFERENCES "public"."asf_department"("id") ON DELETE CASCADE;


--
-- Name: asf_department_role dept_role_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_department_role"
    ADD CONSTRAINT "dept_role_id_foreign" FOREIGN KEY ("role_id") REFERENCES "public"."asf_role"("id") ON DELETE CASCADE;


--
-- Name: asf_role_permission permission_permission_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_role_permission"
    ADD CONSTRAINT "permission_permission_id_foreign" FOREIGN KEY ("permission_id") REFERENCES "public"."asf_permission"("id") ON DELETE CASCADE;


--
-- Name: asf_role_permission permission_role_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_role_permission"
    ADD CONSTRAINT "permission_role_id_foreign" FOREIGN KEY ("role_id") REFERENCES "public"."asf_role"("id") ON DELETE CASCADE;


--
-- Name: asf_account_post post_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_account_post"
    ADD CONSTRAINT "post_id_foreign" FOREIGN KEY ("post_id") REFERENCES "public"."asf_post"("id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

