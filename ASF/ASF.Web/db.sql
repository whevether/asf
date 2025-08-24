--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2 (Debian 17.2-1.pgdg120+1)
-- Dumped by pg_dump version 17.2 (Debian 17.2-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
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
DROP INDEX IF EXISTS "public"."IX_message_title";
DROP INDEX IF EXISTS "public"."IX_help_title";
DROP INDEX IF EXISTS "public"."IX_help_category";
DROP INDEX IF EXISTS "public"."IX_country_name";
DROP INDEX IF EXISTS "public"."IX_country_code";
DROP INDEX IF EXISTS "public"."IX_asf_role_permission_role_id";
DROP INDEX IF EXISTS "public"."IX_asf_role_permission_permission_id";
DROP INDEX IF EXISTS "public"."IX_asf_permission_name";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_title";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_permission_id";
DROP INDEX IF EXISTS "public"."IX_asf_permission_menu_menu_url";
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
DROP INDEX IF EXISTS "public"."IX_appsetting_wrap_name";
ALTER TABLE IF EXISTS ONLY "public"."asf_message_inbox" DROP CONSTRAINT IF EXISTS "asf_message_inbox_pkey";
ALTER TABLE IF EXISTS ONLY "public"."asf_help" DROP CONSTRAINT IF EXISTS "asf_help_pkey";
ALTER TABLE IF EXISTS ONLY "public"."asf_country" DROP CONSTRAINT IF EXISTS "asf_country_pkey";
ALTER TABLE IF EXISTS ONLY "public"."asf_app_setting" DROP CONSTRAINT IF EXISTS "asf_app_setting_pkey";
ALTER TABLE IF EXISTS ONLY "public"."asf_tenancy" DROP CONSTRAINT IF EXISTS "PK_asf_tenancy";
ALTER TABLE IF EXISTS ONLY "public"."asf_security_token" DROP CONSTRAINT IF EXISTS "PK_asf_security_token";
ALTER TABLE IF EXISTS ONLY "public"."asf_role_permission" DROP CONSTRAINT IF EXISTS "PK_asf_role_permission";
ALTER TABLE IF EXISTS ONLY "public"."asf_role" DROP CONSTRAINT IF EXISTS "PK_asf_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_post" DROP CONSTRAINT IF EXISTS "PK_asf_post";
ALTER TABLE IF EXISTS ONLY "public"."asf_permission_menu" DROP CONSTRAINT IF EXISTS "PK_asf_permission_menu";
ALTER TABLE IF EXISTS ONLY "public"."asf_permission" DROP CONSTRAINT IF EXISTS "PK_asf_permission";
ALTER TABLE IF EXISTS ONLY "public"."asf_loginfos" DROP CONSTRAINT IF EXISTS "PK_asf_loginfos";
ALTER TABLE IF EXISTS ONLY "public"."asf_department_role" DROP CONSTRAINT IF EXISTS "PK_asf_department_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_department" DROP CONSTRAINT IF EXISTS "PK_asf_department";
ALTER TABLE IF EXISTS ONLY "public"."asf_apis" DROP CONSTRAINT IF EXISTS "PK_asf_apis";
ALTER TABLE IF EXISTS ONLY "public"."asf_accounts" DROP CONSTRAINT IF EXISTS "PK_asf_accounts";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_role" DROP CONSTRAINT IF EXISTS "PK_asf_account_role";
ALTER TABLE IF EXISTS ONLY "public"."asf_account_post" DROP CONSTRAINT IF EXISTS "PK_asf_account_post";
DROP TABLE IF EXISTS "public"."asf_translate";
DROP SEQUENCE IF EXISTS "public"."asf_tenancy_id_seq";
DROP TABLE IF EXISTS "public"."asf_tenancy";
DROP SEQUENCE IF EXISTS "public"."asf_security_token_id_seq";
DROP TABLE IF EXISTS "public"."asf_security_token";
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
DROP TABLE IF EXISTS "public"."asf_message_inbox";
DROP SEQUENCE IF EXISTS "public"."asf_loginfos_id_seq";
DROP TABLE IF EXISTS "public"."asf_loginfos";
DROP TABLE IF EXISTS "public"."asf_help";
DROP TABLE IF EXISTS "public"."asf_dictionary";
DROP SEQUENCE IF EXISTS "public"."asf_department_role_id_seq";
DROP TABLE IF EXISTS "public"."asf_department_role";
DROP SEQUENCE IF EXISTS "public"."asf_department_id_seq";
DROP TABLE IF EXISTS "public"."asf_department";
DROP TABLE IF EXISTS "public"."asf_country";
DROP TABLE IF EXISTS "public"."asf_app_setting";
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
-- Name: asf_app_setting; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_app_setting" (
    "id" bigint NOT NULL,
    "wrap_name" character varying(255) NOT NULL,
    "os_type " integer DEFAULT 0,
    "version_no " character varying(255) NOT NULL,
    "version_name " character varying(255) NOT NULL,
    "content " character varying NOT NULL,
    "down_url " character varying(255) NOT NULL,
    "wrap_size " numeric(10,2) DEFAULT 0,
    "update_status " integer DEFAULT 0,
    "update_type" integer DEFAULT 2,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "update_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_app_setting"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_app_setting" IS 'app设置表';


--
-- Name: COLUMN "asf_app_setting"."wrap_name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."wrap_name" IS '包名';


--
-- Name: COLUMN "asf_app_setting"."os_type "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."os_type " IS '系统类型 0 安卓 1 ios';


--
-- Name: COLUMN "asf_app_setting"."version_no "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."version_no " IS '版本号';


--
-- Name: COLUMN "asf_app_setting"."version_name "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."version_name " IS '版本名称';


--
-- Name: COLUMN "asf_app_setting"."content "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."content " IS '更新内容';


--
-- Name: COLUMN "asf_app_setting"."down_url "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."down_url " IS '下载地址';


--
-- Name: COLUMN "asf_app_setting"."wrap_size "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."wrap_size " IS '包体积';


--
-- Name: COLUMN "asf_app_setting"."update_status "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."update_status " IS '更新开启状态， 0不开启 1开启';


--
-- Name: COLUMN "asf_app_setting"."update_type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."update_type" IS '更新类型 0 强制升级 1 强提示升级 2 弱提示升级';


--
-- Name: COLUMN "asf_app_setting"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_app_setting"."update_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_app_setting"."update_time" IS '修改时间';


--
-- Name: asf_app_setting_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_app_setting" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_app_setting_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_country; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_country" (
    "id" bigint NOT NULL,
    "name" character varying(255) NOT NULL,
    "language_code" character varying(255) NOT NULL,
    "currency_type" character varying(255) NOT NULL,
    "ratio" numeric DEFAULT 0,
    "withdrawal_ratio" numeric DEFAULT 0,
    "status" integer DEFAULT 1,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "update_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


--
-- Name: TABLE "asf_country"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_country" IS '国家表';


--
-- Name: COLUMN "asf_country"."id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."id" IS '国家id';


--
-- Name: COLUMN "asf_country"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."name" IS '国家名称';


--
-- Name: COLUMN "asf_country"."language_code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."language_code" IS '国家code';


--
-- Name: COLUMN "asf_country"."currency_type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."currency_type" IS '国家币种';


--
-- Name: COLUMN "asf_country"."ratio"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."ratio" IS '国家与RMB之间汇率';


--
-- Name: COLUMN "asf_country"."withdrawal_ratio"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."withdrawal_ratio" IS '提现手续费利率';


--
-- Name: COLUMN "asf_country"."status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."status" IS '状态 0 禁用, 1 启用';


--
-- Name: COLUMN "asf_country"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_country"."update_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_country"."update_time" IS '修改时间时间';


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
    "name" "text" NOT NULL,
    "code" character varying(255) NOT NULL,
    "tenancy_id" bigint,
    "key" character varying(255) NOT NULL,
    "value" character varying(255) NOT NULL,
    "options" character varying(255),
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "country_code" character varying(255) NOT NULL,
    "add_user" character varying(255) NOT NULL
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

COMMENT ON COLUMN "public"."asf_dictionary"."key" IS '字典键 关联多语言表的key';


--
-- Name: COLUMN "asf_dictionary"."value"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."value" IS '字典值';


--
-- Name: COLUMN "asf_dictionary"."options"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."options" IS '字典额外配置';


--
-- Name: COLUMN "asf_dictionary"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_dictionary"."country_code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."country_code" IS '国家名称';


--
-- Name: COLUMN "asf_dictionary"."add_user"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_dictionary"."add_user" IS '添加人';


--
-- Name: asf_dictionary_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_dictionary" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_dictionary_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: asf_help; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_help" (
    "id" bigint NOT NULL,
    "country_code" character varying(250) NOT NULL,
    "category_key " character varying(255) NOT NULL,
    "title_key" character varying(255) NOT NULL,
    "content_key" character varying(255) NOT NULL,
    "status" integer DEFAULT 1,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "category" character varying(255) NOT NULL,
    "title" character varying(255) NOT NULL,
    "content" character varying(255) NOT NULL
);


--
-- Name: TABLE "asf_help"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_help" IS '帮助表';


--
-- Name: COLUMN "asf_help"."id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."id" IS '帮助id';


--
-- Name: COLUMN "asf_help"."country_code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."country_code" IS '国家代码';


--
-- Name: COLUMN "asf_help"."category_key "; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."category_key " IS '问题分类 多语言表key';


--
-- Name: COLUMN "asf_help"."title_key"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."title_key" IS '问题标题 多语言表 key';


--
-- Name: COLUMN "asf_help"."content_key"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."content_key" IS '问题内容 多语言表 key';


--
-- Name: COLUMN "asf_help"."status"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."status" IS '问题状态 0 禁用 1 启用';


--
-- Name: COLUMN "asf_help"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_help"."category"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."category" IS '问题分类 中文名称';


--
-- Name: COLUMN "asf_help"."title"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."title" IS '问题标题 中文名称';


--
-- Name: COLUMN "asf_help"."content"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_help"."content" IS '问题内容 中文名称';


--
-- Name: asf_help_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_help" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_help_id_seq"
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
-- Name: asf_message_inbox; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE "public"."asf_message_inbox" (
    "id" bigint NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "content" "text",
    "title" character varying(255) NOT NULL,
    "is_have_read" smallint DEFAULT 0,
    "read_time" timestamp(6) with time zone,
    "user_id" bigint,
    "img" character varying(255),
    "type" integer DEFAULT 0
);


--
-- Name: TABLE "asf_message_inbox"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_message_inbox" IS '站内信消息';


--
-- Name: COLUMN "asf_message_inbox"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_message_inbox"."content"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."content" IS '文字内容或链接内容';


--
-- Name: COLUMN "asf_message_inbox"."title"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."title" IS '标题';


--
-- Name: COLUMN "asf_message_inbox"."is_have_read"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."is_have_read" IS '是否已读';


--
-- Name: COLUMN "asf_message_inbox"."read_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."read_time" IS '已读时间';


--
-- Name: COLUMN "asf_message_inbox"."user_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."user_id" IS '站内信发送的用户id,如果为空则是全部用户';


--
-- Name: COLUMN "asf_message_inbox"."img"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."img" IS '消息背景图';


--
-- Name: COLUMN "asf_message_inbox"."type"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_message_inbox"."type" IS '消息类型 0，系统通知 1 动态,2审核结果，3：举报结果, 4:新的粉丝';


--
-- Name: asf_message_inbox_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_message_inbox" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_message_inbox_id_seq"
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
    "key" character varying(500) NOT NULL,
    "value" "text" NOT NULL,
    "country_code" character varying(255) NOT NULL,
    "add_user" character varying(255) NOT NULL,
    "create_time" timestamp(6) without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "is_admin" smallint DEFAULT 0
);


--
-- Name: TABLE "asf_translate"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON TABLE "public"."asf_translate" IS '多语言表';


--
-- Name: COLUMN "asf_translate"."name"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."name" IS '中文名称';


--
-- Name: COLUMN "asf_translate"."tenancy_id"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."tenancy_id" IS '租户id';


--
-- Name: COLUMN "asf_translate"."key"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."key" IS '多语言key 例如性别 sex.man';


--
-- Name: COLUMN "asf_translate"."value"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."value" IS '多语言值内容 例如 男';


--
-- Name: COLUMN "asf_translate"."country_code"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."country_code" IS '国家语言code 利用国家code 分组 例如zh en 等等';


--
-- Name: COLUMN "asf_translate"."add_user"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."add_user" IS '添加者';


--
-- Name: COLUMN "asf_translate"."create_time"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."create_time" IS '创建时间';


--
-- Name: COLUMN "asf_translate"."is_admin"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN "public"."asf_translate"."is_admin" IS '是否为管理后台 0 否 1 是';


--
-- Name: asf_translate_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE "public"."asf_translate" ALTER COLUMN "id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME "public"."asf_translate_id_seq"
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

INSERT INTO "public"."asf_accounts" VALUES (348851403578789888, 1, 2, 'test', 'test111', 'cu7mQ8t0LplfAp5GiAbi/6dwkZhZcM/anBnxn9Pn/6E=', 'bfdf4f78-27fd-43d4-b24f-c11824d27b8b', '86+', NULL, NULL, 1, 0, 2, 1, '2022-11-19 15:30:56.104313', '127.0.0.1', '2023-11-18 05:48:06.206454+00', '本地', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoic3VwZXJhZG1pbiIsIm5hbWUiOiJ0ZXN0MTExIiwic3ViIjoiMzQ4ODUxNDAzNTc4Nzg5ODg4IiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzAwMjg2NDg2LCJleHAiOjE3MDAzNzI4ODYsImlhdCI6MTcwMDI4NjQ4NiwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.ixnjqR7PJVQvSwl25sookDbFiVv8s9tFAqgspXUFPpl_bb7QbsFNbqJmtsBKB2-oR9cUKBKwzke3XjMkpt8wBNPqUeI8I2LJKs0ynmYB0L-DFJh2tn2zlXLw1l0YsC02FuPryKMxwOZP61rG_KdJLTRwCbaT58onN6Qm3sSRDhKzIYVG0PX1RgjDhy_noT-63Ya8N4u-GKy37Ut1k4U5MOfDRQiAzjutQGUryNS9yr3liwhDtPKpHrq71ZT97GJ01-1jdiU4RN9ei8g_74ktHXRuAR6KLXvIuMIwReG7x-Noq304YMESG9t_bUZXD21aBCZ27pCp6AafczNtnqVwFQ', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJyb2xlIjoic3VwZXJhZG1pbiIsIm5hbWUiOiJ0ZXN0MTExIiwic3ViIjoiMzQ4ODUxNDAzNTc4Nzg5ODg4IiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzAwMjg2NDg2LCJleHAiOjE3MDA0MTYwODYsImlhdCI6MTcwMDI4NjQ4NiwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.lvpnK8HJYhd23-1JZn9c7nAYmZrFi6Em_AOoewyfsOccfxLhngNtVY2In6IU0t9emAxDLbCTh-4fU6NizGL1IKn_jtPEUMT0yzpAYmkCcByrVfc7AENGSnKbWiRj2VIg904DcJdKHZhL5cXFc3P4KU4vHz7D4f2T1MxKP7whMT3-Sjl8XtnCiid-XCVZZmRPSPpbjumjxHgHWG3dU5ck9EdiFSiICox-7yFn6-N-UlBjA70gaGStGG8NXWBGJGFvh7po3FKVTb80roaZlXwzj9H8GWOQF1zrid2kE8PS4eNJX6MVU58RYhgnrHNHe60LVZU-KdlLoxv6Fo2EJgXM9A', '2023-11-19 05:48:06.206452+00');
INSERT INTO "public"."asf_accounts" VALUES (1, 1, 2, 'keep_wan', 'admin', '20V6MgmX8XVtiRz10AI4Ib5H16a9JyrNmSwmgJ2k0iI=', '8283e4c3-f87e-4d85-85fb-f5c0de063992', '86+13800000000', 'admin@qq.com', 'https://minioapi.zytravel.shop/avatar/333128767074963456avatarGroup1052.png', 1, 0, 1, 0, '2021-11-15 07:21:24.550098', '127.0.0.1', '2025-08-24 13:38:10.553781+00', '本地', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzU2MDQyNjkwLCJleHAiOjE3NTYxMjkwOTAsImlhdCI6MTc1NjA0MjY5MCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.VaW6iHxXQhZIX8e3CtSGgbXMN_4J6Z4qYu7YRqickqBINInuupoYP_N6SpuAymR5fldYcIloeAHDyBkAZKRZH-ROjSrMXWgGtGatIOop47N8j-4u84uS7enJg4EnKUs_lS1Gtks0bgHXpAJwQ4iCI3UlAb4hq2rTupNa0aKzU4N0_q95VmWRRP-eNGQjh8cl4GgT3CpI-HUg9-_czXT_Ylbv3EGS6ZFrnw9WaWRt7Vw-lCnbBCmwDD1-6f4_BulH6VRI35RytYRl-a2N5Y52iZJJ_uITKSmoyqbnBY7T6ZgM1qxMZAVJ_YCG-mJPJjGQ58hzkrZfKIHUuIyYxEG3vw', 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzU2MDQyNjkwLCJleHAiOjE3NTYxNzIyOTAsImlhdCI6MTc1NjA0MjY5MCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.ZYPWbVfvB9VEfHxFwwdrZtrN9BT7tDeJeIz60YgP5_Kq1JRNUr-_gm80SilPEXlEsUgkTsrqPVH12DiaSnt1jb9rsH0lDw_nwjWUiLcDZGeuboQocAw_XCOpDbHSZ42t0Nlk4ViAOSR5HJdZw033lWJt-aEAkvvYJHbah10SlcvUw1m4BXxkuN666v30HXE010YKkhjhbyHdkg5XUC4sd86cZqHEi0Rhww20Y3qZLvpJ1nrK3mN6yVjbanDxEnnUBPd7_xEUMifuMc8cXLl9RReso2hdoDtj-7UcCnUnee1hCYexG_iS93OajsPffJiJ-5iiADNCVL0zN_5Cr3DIIA', '2025-08-25 13:38:10.441893+00');


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
INSERT INTO "public"."asf_apis" VALUES (82, 16, '登出', 1, 1, '/api/asf/authorise/logout', 'post', 0, '登出账户权限', 1, 1, '2022-11-19 12:47:26.73461');
INSERT INTO "public"."asf_apis" VALUES (83, 16, '获取登录账户信息', 1, 1, '/api/asf/account/accountinfo', 'get', 0, '用户信息权限', 1, 1, '2022-11-19 12:47:26.739072');
INSERT INTO "public"."asf_apis" VALUES (84, 16, '获取租户列表集合', 1, 1, '/api/asf/tenancy/getlists', 'get', 0, '获取租户列表集合', 1, 1, '2022-11-19 12:47:26.742038');
INSERT INTO "public"."asf_apis" VALUES (85, 16, '上传文件', 1, 1, '/api/asf/upload/index', 'post,put', 0, '上传文件', 1, 1, '2022-11-19 12:47:26.744994');
INSERT INTO "public"."asf_apis" VALUES (61, 389447780190613504, '获取部门详情', 1, 2, '/api/asf/department/details', 'get', 0, '获取部门详情权限', 1, 1, '2022-11-19 12:47:26.682653');
INSERT INTO "public"."asf_apis" VALUES (5, 389431849661984768, '获取账户详情', 1, 2, '/api/asf/account/details', 'get', 0, '获取账户信息详情权限', 1, 1, '2022-11-19 12:47:26.541004');
INSERT INTO "public"."asf_apis" VALUES (20, 394410371264667648, '获取权限详情', 1, 2, '/api/asf/permission/details', 'get', 0, '获取权限详情权限', 1, 1, '2022-11-19 12:47:26.577645');
INSERT INTO "public"."asf_apis" VALUES (478195627765690368, 478194271101284352, '获取国家分页列表', 1, 2, '/api/asf/country/getlist', 'get', 0, '获取国家分页列表', 1, 1, '2023-11-11 13:38:42.179308');
INSERT INTO "public"."asf_apis" VALUES (478195852186120192, 478194271101284352, '获取所有国家列表', 1, 1, '/api/asf/country/getlists', 'get', 0, '获取所有国家列表', 1, 1, '2023-11-11 13:39:35.668905');
INSERT INTO "public"."asf_apis" VALUES (478196634209906688, 478194271101284352, '修改国家', 1, 2, '/api/asf/country/modify', 'post,put', 1, '修改国家', 0, 1, '2023-11-11 13:42:42.122734');
INSERT INTO "public"."asf_apis" VALUES (478196317766447104, 478194271101284352, '添加国家', 1, 2, '/api/asf/country/create', 'post', 1, '添加国家', 1, 1, '2023-11-11 13:41:26.675366');
INSERT INTO "public"."asf_apis" VALUES (478196932382978048, 478194271101284352, '获取国家详情', 1, 2, '/api/asf/country/getdetails', 'get', 0, '获取国家详情', 1, 1, '2023-11-11 13:43:53.215507');
INSERT INTO "public"."asf_apis" VALUES (44, 9, '删除日志', 1, 2, '/api/asf/audio/deletelog', 'post,delete', 0, '删除日志信息权限', 1, 1, '2022-11-19 12:47:26.627332');
INSERT INTO "public"."asf_apis" VALUES (478197264722849792, 478194271101284352, '删除国家', 1, 2, '/api/asf/country/delete/[0-9]{1,100}', 'post', 1, '删除国家', 1, 1, '2023-11-11 13:45:12.454684');
INSERT INTO "public"."asf_apis" VALUES (486440849298427904, 485352564237463552, '修改会员国家', 1, 2, '/api/asf/member/ModifyMemberCountry', 'put', 0, '修改会员国家', 0, 1, '2023-12-04 07:42:16.125468');
INSERT INTO "public"."asf_apis" VALUES (486441085437743104, 485352564237463552, '修改会员状态', 1, 2, '/api/asf/member/ModifyMemberStatus', 'put', 0, '修改会员状态', 0, 1, '2023-12-04 07:43:12.392398');
INSERT INTO "public"."asf_apis" VALUES (486442952637026304, 485352564237463552, '修改会员昵称', 1, 2, '/api/asf/member/ModifyMemberNickName', 'put', 0, '修改会员昵称', 0, 1, '2023-12-04 07:50:37.588735');
INSERT INTO "public"."asf_apis" VALUES (486443099852902400, 485352564237463552, '修改会员性别', 1, 2, '/api/asf/member/ModifyMemberSex', 'put', 0, '修改会员性别', 0, 1, '2023-12-04 07:51:12.656244');
INSERT INTO "public"."asf_apis" VALUES (486443317025574912, 485352564237463552, '修改会员年龄', 1, 2, '/api/asf/member/ModifyMemberAge', 'put', 0, '修改会员年龄', 0, 1, '2023-12-04 07:52:04.432369');
INSERT INTO "public"."asf_apis" VALUES (486446156267393024, 485352564237463552, '修改会员补充信息', 1, 2, '/api/asf/member/ModifyMemberInfo', 'put', 0, '修改会员补充信息', 0, 1, '2023-12-04 08:03:21.353518');
INSERT INTO "public"."asf_apis" VALUES (486447556913557504, 485352564237463552, '修改会员推荐值', 1, 2, '/api/asf/member/ModifyMemberRecommend', 'put', 0, '修改会员推荐值', 0, 1, '2023-12-04 08:08:55.357592');
INSERT INTO "public"."asf_apis" VALUES (486447777865297920, 485352564237463552, '修改会员邮箱地址', 1, 2, '/api/asf/member/ModifyMemberEmail', 'put', 0, '修改会员邮箱地址', 0, 1, '2023-12-04 08:09:47.999549');
INSERT INTO "public"."asf_apis" VALUES (486447982064988160, 485352564237463552, '修改会员手机号码', 1, 2, '/api/asf/member/ModifyMemberPhone', 'put', 0, '修改会员手机号码', 0, 1, '2023-12-04 08:10:36.686475');
INSERT INTO "public"."asf_apis" VALUES (486448295626960896, 485352564237463552, '修改会员生日', 1, 2, '/api/asf/member/ModifyMemberBirthday', 'put', 0, '修改会员生日', 0, 1, '2023-12-04 08:11:51.445227');
INSERT INTO "public"."asf_apis" VALUES (486448477580062720, 485352564237463552, '修改会员真人认证状态', 1, 2, '/api/asf/member/ModifyMemberRealAuth', 'put', 0, '修改会员真人认证状态', 0, 1, '2023-12-04 08:12:34.826419');
INSERT INTO "public"."asf_apis" VALUES (486448656764923904, 485352564237463552, '修改会员VIP状态', 1, 2, '/api/asf/member/ModifyMemberVipStatus', 'put', 0, '修改会员VIP状态', 0, 1, '2023-12-04 08:13:17.546322');
INSERT INTO "public"."asf_apis" VALUES (486448958930972672, 485352564237463552, '修改会员受欢迎程度', 1, 2, '/api/asf/member/ModifyMemberRating', 'put', 0, '修改会员受欢迎程度', 0, 1, '2023-12-04 08:14:29.591363');
INSERT INTO "public"."asf_apis" VALUES (486908497639079936, 485352694336385024, '获取会员相册列表', 1, 2, '/api/asf/member/GetMemberAlbumList', 'get', 0, '获取会员相册列表', 0, 1, '2023-12-05 14:40:32.236779');
INSERT INTO "public"."asf_apis" VALUES (486908736177537024, 485352864956477440, '获取会员动态列表', 1, 2, '/api/asf/member/GetMemberTrendsList', 'get', 0, '获取会员动态列表', 0, 1, '2023-12-05 14:41:29.044561');
INSERT INTO "public"."asf_apis" VALUES (487443129837182976, 485352694336385024, '审核相册', 1, 2, '/api/asf/member/MemberAlbumReviewedStatus', 'put', 0, '审核相册', 0, 1, '2023-12-07 02:04:58.458538');
INSERT INTO "public"."asf_apis" VALUES (487443357730496512, 485352864956477440, '审核动态', 1, 2, '/api/asf/member/MemberTrendsReviewedStatus', 'put', 0, '审核动态', 0, 1, '2023-12-07 02:05:52.741007');
INSERT INTO "public"."asf_apis" VALUES (487446191616188416, 485352694336385024, '修改会员相册', 1, 2, '/api/asf/member/ModifyMemberAlbum', 'put', 0, '修改会员相册', 0, 1, '2023-12-07 02:17:08.390133');
INSERT INTO "public"."asf_apis" VALUES (487446349091332096, 485352864956477440, '修改会员动态', 1, 2, '/api/asf/member/ModifyMemberTrends', 'put', 0, '修改会员动态', 0, 1, '2023-12-07 02:17:45.932603');
INSERT INTO "public"."asf_apis" VALUES (487913409977536512, 485380826145681408, '会员社交账号列表', 1, 2, '/api/asf/member/GetMemberSocializeList', 'get', 0, '会员社交账号列表', 0, 1, '2023-12-08 09:13:41.968241');
INSERT INTO "public"."asf_apis" VALUES (490894208410451968, 485352564237463552, '获取会员详情', 1, 1, '/api/asf/member/GetMember', 'get', 0, '获取会员详情', 0, 1, '2023-12-16 14:38:19.701869');
INSERT INTO "public"."asf_apis" VALUES (616167250314895360, 16, '发送邮件', 1, 1, '/api/asf/member/sendEmail', 'post', 0, '发送邮件', 0, 1, '2024-11-26 07:08:40.323424');
INSERT INTO "public"."asf_apis" VALUES (616168544245096448, 16, '验证邮件', 1, 1, '/api/asf/member/verifyEmail', 'post', 0, '验证邮件', 0, 1, '2024-11-26 07:13:48.805778');
INSERT INTO "public"."asf_apis" VALUES (81, 16, '登录', 1, 1, '/api/asf/authorise/login', 'post', 1, '登录账户权限', 1, 1, '2022-11-19 12:47:26.73191');
INSERT INTO "public"."asf_apis" VALUES (613638565401088000, 16, 'APP会员登录', 1, 1, '/api/asf/member/login', 'post', 1, 'APP会员登录', 0, 1, '2024-11-19 07:40:34.853381');
INSERT INTO "public"."asf_apis" VALUES (616823879093915648, 16, '会员注册', 1, 1, '/api/asf/member/register', 'post', 1, '会员注册', 0, 1, '2024-11-28 02:37:52.824685');
INSERT INTO "public"."asf_apis" VALUES (618345517198471168, 16, '添加站内信', 1, 1, '/api/asf/member/addMessageInbox', 'post', 0, '添加站内信', 0, 1, '2024-12-02 07:24:19.605504');
INSERT INTO "public"."asf_apis" VALUES (618345325724299264, 16, '获取站内信列表', 1, 1, '/api/asf/member/getMessageInboxList', 'get', 0, '获取站内信列表', 0, 1, '2024-12-02 07:23:33.968394');
INSERT INTO "public"."asf_apis" VALUES (624444477213388800, 16, '获取关于我们详情', 1, 1, '/api/asf/member/getAbout', 'get', 0, '获取关于我们详情', 0, 1, '2024-12-19 03:19:25.000855');
INSERT INTO "public"."asf_apis" VALUES (627426981067579392, 16, '获取app设置详情', 1, 1, '/api/asf/memberSetting/getAppSetting', 'get', 0, NULL, 0, 1, '2024-12-27 08:50:49.328003');
INSERT INTO "public"."asf_apis" VALUES (485739445368004608, 485352564237463552, '获取会员列表', 1, 1, '/api/asf/member/getmemberlist', 'get', 0, '获取会员列表', 0, 1, '2023-12-02 09:15:08.86806');
INSERT INTO "public"."asf_apis" VALUES (629932393836761088, 16, '修改用户在线状态', 1, 1, '/api/asf/member/modifyUserOnline', 'get', 0, '修改用户在线状态', 0, 1, '2025-01-03 06:46:26.282156');
INSERT INTO "public"."asf_apis" VALUES (631748122889203712, 16, '检查会员是否已经关注/是否为好友', 1, 1, '/api/asf/member/checkUserFlow', 'get', 0, '检查会员是否已经关注/是否为好友', 0, 1, '2025-01-08 07:01:29.82674');
INSERT INTO "public"."asf_apis" VALUES (631748347104112640, 16, ' 添加/取消关注', 1, 1, '/api/asf/member/addUserFlow', 'get', 0, ' 添加/取消关注', 0, 1, '2025-01-08 07:02:23.269678');
INSERT INTO "public"."asf_apis" VALUES (631748535256395776, 16, '获取会员关注列表', 1, 1, '/api/asf/member/getUserFlowList', 'get', 0, '获取会员关注列表', 0, 1, '2025-01-08 07:03:08.127717');
INSERT INTO "public"."asf_apis" VALUES (631748804165808128, 16, '删除好友', 1, 1, '/api/asf/member/deleteUserFriend', 'get', 0, '删除好友', 0, 1, '2025-01-08 07:04:12.240869');
INSERT INTO "public"."asf_apis" VALUES (631748960617541632, 16, '获取好友列表', 1, 1, '/api/asf/member/getUserFriendList', 'get', 0, '获取好友列表', 0, 1, '2025-01-08 07:04:49.541992');
INSERT INTO "public"."asf_apis" VALUES (631749103261626368, 16, '发起好友申请', 1, 1, '/api/asf/member/addMemberFriend', 'get', 0, '发起好友申请', 0, 1, '2025-01-08 07:05:23.553997');
INSERT INTO "public"."asf_apis" VALUES (631749252448825344, 16, '处理好友申请', 1, 1, '/api/asf/member/handleMemberFriend', 'get', 0, '处理好友申请', 0, 1, '2025-01-08 07:05:59.117561');
INSERT INTO "public"."asf_apis" VALUES (631749398297358336, 16, '获取发起的好友申请', 1, 1, '/api/asf/member/getSelfFriendApplyList', 'get', 0, '获取发起的好友申请', 0, 1, '2025-01-08 07:06:33.892318');
INSERT INTO "public"."asf_apis" VALUES (631749571593416704, 16, '获取收到的好友申请', 1, 1, '/api/asf/member/getFriendApplyList', 'get', 0, '获取收到的好友申请', 0, 1, '2025-01-08 07:07:15.210753');
INSERT INTO "public"."asf_apis" VALUES (660045059544363008, 16, '获取标签分组列表', 1, 1, '/api/asf/member/getTagsList', 'get', 0, '获取标签分组列表', 0, 1, '2025-03-27 09:03:25.249494');
INSERT INTO "public"."asf_apis" VALUES (660045381151010816, 660039519033339904, '获取标签列表', 1, 2, '/api/asf/member/getTagPageList', 'get', 0, '获取标签列表', 0, 1, '2025-03-27 09:04:41.916862');
INSERT INTO "public"."asf_apis" VALUES (660045689973420032, 660039519033339904, '添加标签', 1, 2, '/api/asf/member/addTags', 'post', 0, '添加标签', 0, 1, '2025-03-27 09:05:55.544504');
INSERT INTO "public"."asf_apis" VALUES (660046087534718976, 660039519033339904, '获取标签详情', 1, 2, '/api/asf/member/getTags', 'get', 0, '获取标签详情', 0, 1, '2025-03-27 09:07:30.364054');
INSERT INTO "public"."asf_apis" VALUES (660045853584830464, 660039519033339904, '修改标签', 1, 2, '/api/asf/member/modifyTags', 'put', 0, '修改标签', 0, 1, '2025-03-27 09:06:34.552362');


--
-- Data for Name: asf_app_setting; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_app_setting" VALUES (2, 'com.xqtech.web3', 0, '0.0.2', 'android第一版', '1. 修改432432;











2. 修改432432;











3. 修改432432;











4. 修改432432;', 'https://baidu.com', 89.40, 1, 2, '2024-12-27 07:53:56.341973', '2024-12-27 07:53:56.341973');
INSERT INTO "public"."asf_app_setting" VALUES (1, 'com.xqtech.web3', 1, '0.0.2', 'ios第一版', '1. 修改432432;











2. 修改432432;











3. 修改432432;











4. 修改432432;', 'https://baidu.com', 89.40, 1, 2, '2024-12-27 07:53:56.341973', '2024-12-27 07:53:56.341973');


--
-- Data for Name: asf_country; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_country" VALUES (478209762849501184, '越南', 'VN', 'VND', 3337.06, 0.8, 1, '2023-11-11 14:34:52.194722', '2023-11-11 14:34:52.194722');
INSERT INTO "public"."asf_country" VALUES (478208138663997440, '印尼', 'ID', 'IDR', 2153.14, 1.2, 1, '2023-11-11 14:28:24.920281', '2023-11-11 14:28:24.920281');
INSERT INTO "public"."asf_country" VALUES (478206895237410816, '中国', 'CN', 'CNY', 1, 0.08, 1, '2023-11-11 14:23:28.568622', '2023-11-11 14:23:28.568622');
INSERT INTO "public"."asf_country" VALUES (478209018306015232, '马来西亚', 'MY', 'MYR', 0.6459, 1.3, 1, '2023-11-11 14:31:54.676922', '2023-11-11 14:31:54.676922');
INSERT INTO "public"."asf_country" VALUES (478209996732280832, '菲律宾', 'PH', 'PHP', 7.6609, 1.2, 1, '2023-11-11 14:35:47.959581', '2023-11-11 14:35:47.959581');
INSERT INTO "public"."asf_country" VALUES (478211147452166144, '泰国', 'TH', 'THB', 4.9319, 1.3, 1, '2023-11-11 14:40:22.259135', '2023-11-11 14:40:22.259135');
INSERT INTO "public"."asf_country" VALUES (478211559135686656, '印度', 'IN', 'INR', 11.4296, 1.22, 1, '2023-11-11 14:42:00.41133', '2023-11-11 14:42:00.41133');


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
-- Data for Name: asf_help; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- Data for Name: asf_loginfos; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_loginfos" VALUES (714471547210039296, 0, NULL, 3, '异常消息', '127.0.0.1', '本地', NULL, '2025-08-24 13:34:51.229557', '/api/asf/translate/getLists', '?isAdmin=true', '42703: column a.country does not exist

POSITION: 26', '操作记录');
INSERT INTO "public"."asf_loginfos" VALUES (714471584795197440, 0, NULL, 3, '异常消息', '127.0.0.1', '本地', NULL, '2025-08-24 13:35:00.061352', '/api/asf/translate/getLists', '?isAdmin=true', '42703: column a.country does not exist

POSITION: 26', '操作记录');
INSERT INTO "public"."asf_loginfos" VALUES (714472384170524672, 0, NULL, 2, '登录', '127.0.0.1', '本地', 16, '2025-08-24 13:38:10.682564', '/api/asf/authorise/login', '{"tenancyId":"1","username":"admin","password":"admin","remember":true,"loginType":"account"}', '{"result":{"token":"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzU2MDQyNjkwLCJleHAiOjE3NTYxMjkwOTAsImlhdCI6MTc1NjA0MjY5MCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.VaW6iHxXQhZIX8e3CtSGgbXMN_4J6Z4qYu7YRqickqBINInuupoYP_N6SpuAymR5fldYcIloeAHDyBkAZKRZH-ROjSrMXWgGtGatIOop47N8j-4u84uS7enJg4EnKUs_lS1Gtks0bgHXpAJwQ4iCI3UlAb4hq2rTupNa0aKzU4N0_q95VmWRRP-eNGQjh8cl4GgT3CpI-HUg9-_czXT_Ylbv3EGS6ZFrnw9WaWRt7Vw-lCnbBCmwDD1-6f4_BulH6VRI35RytYRl-a2N5Y52iZJJ_uITKSmoyqbnBY7T6ZgM1qxMZAVJ_YCG-mJPJjGQ58hzkrZfKIHUuIyYxEG3vw","tokenType":"Bearer","refreshToken":"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzU2MDQyNjkwLCJleHAiOjE3NTYxNzIyOTAsImlhdCI6MTc1NjA0MjY5MCwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.ZYPWbVfvB9VEfHxFwwdrZtrN9BT7tDeJeIz60YgP5_Kq1JRNUr-_gm80SilPEXlEsUgkTsrqPVH12DiaSnt1jb9rsH0lDw_nwjWUiLcDZGeuboQocAw_XCOpDbHSZ42t0Nlk4ViAOSR5HJdZw033lWJt-aEAkvvYJHbah10SlcvUw1m4BXxkuN666v30HXE010YKkhjhbyHdkg5XUC4sd86cZqHEi0Rhww20Y3qZLvpJ1nrK3mN6yVjbanDxEnnUBPd7_xEUMifuMc8cXLl9RReso2hdoDtj-7UcCnUnee1hCYexG_iS93OajsPffJiJ-5iiADNCVL0zN_5Cr3DIIA","expired":1756129090},"status":200,"message":"Success"}', '操作记录');


--
-- Data for Name: asf_message_inbox; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_message_inbox" VALUES (1, '2024-12-02 06:57:07.105038', 'https://baidu.com', '测试11', 0, NULL, NULL, NULL, 0);


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
INSERT INTO "public"."asf_permission" VALUES (331075142022815744, '/user/center', 0, '个人中心', 3, 1, NULL, 0, 1, 1, '2022-11-19 12:47:26.516298');
INSERT INTO "public"."asf_permission" VALUES (389431849661984768, '/control/account/details', 3, '账户详情权限', 3, 1, '账户详情权限', 0, 1, 1, '2023-03-11 15:03:08.299071');
INSERT INTO "public"."asf_permission" VALUES (389447011546656768, '/control/role/details', 7, '角色详情权限', 3, 1, '角色详情权限', 0, 1, 1, '2023-03-11 16:03:23.147601');
INSERT INTO "public"."asf_permission" VALUES (389447780190613504, '/control/department/details', 12, '部门详情权限', 3, 1, '部门详情权限', 0, 1, 1, '2023-03-11 16:06:26.409813');
INSERT INTO "public"."asf_permission" VALUES (394410371264667648, '/control/permission/details', 4, '权限详情', 3, 0, '权限详情', 0, 1, 1, '2023-03-25 08:46:00.326874');
INSERT INTO "public"."asf_permission" VALUES (478194271101284352, '/control/country', 2, '国家权限', 1, 1, '国家权限', 0, 1, 1, '2023-11-11 13:33:18.703352');
INSERT INTO "public"."asf_permission" VALUES (485352284338974720, '/member', 0, '会员管理', 1, 0, '会员管理权限', 0, 1, 1, '2023-12-01 07:36:42.093741');
INSERT INTO "public"."asf_permission" VALUES (485352564237463552, '/member/memberlist', 485352284338974720, '会员列表', 2, 0, '会员列表权限', 0, 1, 1, '2023-12-01 07:37:48.741595');
INSERT INTO "public"."asf_permission" VALUES (485352864956477440, '/member/membertrends', 485352284338974720, '会员动态', 2, 0, '会员动态权限', 0, 1, 1, '2023-12-01 07:39:00.439903');
INSERT INTO "public"."asf_permission" VALUES (485363648935686144, '/setting', 0, '社交设置', 1, 0, '社交设置权限', 0, 1, 1, '2023-12-01 08:21:51.732442');
INSERT INTO "public"."asf_permission" VALUES (485364164180766720, '/setting/app', 485363648935686144, 'app设置', 2, 0, 'app设置权限', 0, 1, 1, '2023-12-01 08:23:54.379347');
INSERT INTO "public"."asf_permission" VALUES (485363950019604480, '/setting/active', 485363648935686144, '活动设置', 2, 0, '活动设置权限', 0, 1, 1, '2023-12-01 08:23:03.317867');
INSERT INTO "public"."asf_permission" VALUES (485364447438893056, '/setting/banner', 485363648935686144, 'banner 图设置', 2, 0, 'banner 图设置权限', 0, 1, 1, '2023-12-01 08:25:01.903995');
INSERT INTO "public"."asf_permission" VALUES (485364645519093760, '/setting/call', 485363648935686144, '招呼语句设置', 2, 0, '招呼语句设置权限', 0, 1, 1, '2023-12-01 08:25:49.130174');
INSERT INTO "public"."asf_permission" VALUES (485364858954641408, '/setting/charge', 485363648935686144, '收费设置', 2, 0, '收费设置权限', 0, 1, 1, '2023-12-01 08:26:40.017605');
INSERT INTO "public"."asf_permission" VALUES (485365171203796992, '/setting/color', 485363648935686144, '颜色地址设置', 2, 0, '颜色地址设置权限', 0, 1, 1, '2023-12-01 08:27:54.465732');
INSERT INTO "public"."asf_permission" VALUES (485365440721383424, '/setting/currency', 485363648935686144, '货币分成设置', 2, 0, '货币分成设置权限', 0, 1, 1, '2023-12-01 08:28:58.725506');
INSERT INTO "public"."asf_permission" VALUES (485365912324730880, '/setting/exchange', 485363648935686144, '货币兑换', 2, 0, '货币兑换权限', 0, 1, 1, '2023-12-01 08:30:51.166007');
INSERT INTO "public"."asf_permission" VALUES (485368073548918784, '/member/avatar', 485352284338974720, '头像审核', 2, 0, '头像审核权限', 0, 1, 1, '2023-12-01 08:39:26.444555');
INSERT INTO "public"."asf_permission" VALUES (485368188766449664, '/member/sign', 485352284338974720, '签名审核', 2, 0, '签名审核权限', 0, 1, 1, '2023-12-01 08:39:53.915554');
INSERT INTO "public"."asf_permission" VALUES (485368357465550848, '/member/nickname', 485352284338974720, '昵称审核', 2, 0, '昵称审核权限', 0, 1, 1, '2023-12-01 08:40:34.139918');
INSERT INTO "public"."asf_permission" VALUES (485368484557156352, '/member/real', 485352284338974720, '真人认证', 2, 0, '真人认证权限', 0, 1, 1, '2023-12-01 08:41:04.444068');
INSERT INTO "public"."asf_permission" VALUES (485368776342302720, '/setting/gift_price', 485363648935686144, '礼物价格', 2, 0, '礼物价格权限', 0, 1, 1, '2023-12-01 08:42:14.011947');
INSERT INTO "public"."asf_permission" VALUES (485369312634400768, '/setting/nav', 485363648935686144, '导航设置', 2, 0, '导航设置权限', 0, 1, 1, '2023-12-01 08:44:21.876531');
INSERT INTO "public"."asf_permission" VALUES (485369079917637632, '/setting/help', 485363648935686144, '帮助设置', 2, 0, '帮助设置权限', 0, 1, 1, '2023-12-01 08:43:26.39151');
INSERT INTO "public"."asf_permission" VALUES (485369995576143872, '/setting/other', 485363648935686144, '其他设置', 2, 0, '其他设置权限', 0, 1, 1, '2023-12-01 08:47:04.703411');
INSERT INTO "public"."asf_permission" VALUES (485370273377480704, '/setting/recharge_price', 485363648935686144, '充值价格设置', 2, 0, '充值价格设置权限', 0, 1, 1, '2023-12-01 08:48:10.936433');
INSERT INTO "public"."asf_permission" VALUES (485370518333222912, '/setting/sensitive', 485363648935686144, '敏感词设置', 2, 0, '敏感词设置权限', 0, 1, 1, '2023-12-01 08:49:09.340261');
INSERT INTO "public"."asf_permission" VALUES (485370677171515392, '/setting/share', 485363648935686144, '分享设置', 2, 0, '分享设置权限', 0, 1, 1, '2023-12-01 08:49:47.210022');
INSERT INTO "public"."asf_permission" VALUES (485370971976560640, '/member/blacklist', 485352284338974720, '会员黑明单', 2, 0, '会员黑明单权限', 0, 1, 1, '2023-12-01 08:50:57.501346');
INSERT INTO "public"."asf_permission" VALUES (485371141669711872, '/member/device', 485352284338974720, '会员绑定设备', 2, 0, '会员绑定设备权限', 0, 1, 1, '2023-12-01 08:51:37.958315');
INSERT INTO "public"."asf_permission" VALUES (485374635382337536, '/member/flow', 485352284338974720, '会员关注', 2, 0, '会员关注权限', 0, 1, 1, '2023-12-01 09:05:30.917412');
INSERT INTO "public"."asf_permission" VALUES (485377691046047744, '/member/gift', 485352284338974720, '会员礼券', 2, 0, '会员礼券权限', 0, 1, 1, '2023-12-01 09:17:39.448986');
INSERT INTO "public"."asf_permission" VALUES (485377839499243520, '/member/gift_record', 485352284338974720, '会员礼券记录', 2, 0, '会员礼券记录权限', 0, 1, 1, '2023-12-01 09:18:14.839968');
INSERT INTO "public"."asf_permission" VALUES (485379729205161984, '/member/payment_record', 485352284338974720, '会员支付记录', 2, 0, '会员支付记录权限', 0, 1, 1, '2023-12-01 09:25:45.421378');
INSERT INTO "public"."asf_permission" VALUES (485379905353347072, '/member/purchase_history', 485352284338974720, '会员消费记录', 2, 0, '会员消费记录权限', 0, 1, 1, '2023-12-01 09:26:27.419091');
INSERT INTO "public"."asf_permission" VALUES (485352694336385024, '/member/memberalbum', 485352284338974720, '会员相册', 2, 0, '会员相册权限', 0, 1, 1, '2023-12-01 07:38:19.867218');
INSERT INTO "public"."asf_permission" VALUES (485380090871607296, '/member/setting', 485352284338974720, '会员设置', 2, 0, '会员设置权限', 0, 1, 1, '2023-12-01 09:27:11.651377');
INSERT INTO "public"."asf_permission" VALUES (485380826145681408, '/member/socialize', 485352284338974720, '会员社交账号', 2, 0, '会员社交账号权限', 0, 1, 1, '2023-12-01 09:30:06.958843');
INSERT INTO "public"."asf_permission" VALUES (485381004583956480, '/member/withdrawal_record', 485352284338974720, '会员提现记录', 2, 0, '会员提现记录权限', 0, 1, 1, '2023-12-01 09:30:49.502217');
INSERT INTO "public"."asf_permission" VALUES (485381179968778240, '/setting/vip_price', 485363648935686144, 'vip价格设置', 2, 0, 'vip价格设置权限', 0, 1, 1, '2023-12-01 09:31:31.319777');
INSERT INTO "public"."asf_permission" VALUES (485381332217819136, '/setting/withdrawal_setting', 485363648935686144, '提现设置', 2, 0, '提现设置权限', 0, 1, 1, '2023-12-01 09:32:07.61905');
INSERT INTO "public"."asf_permission" VALUES (485378624828141568, '/member/income', 485352284338974720, '会员收益', 2, 0, '会员收益权限', 0, 1, 1, '2023-12-01 09:21:22.08056');
INSERT INTO "public"."asf_permission" VALUES (660039519033339904, '/member/tags', 485352284338974720, '会员标签', 2, 0, '会员标签', 0, 1, 1, '2025-03-27 08:41:24.297508');


--
-- Data for Name: asf_permission_menu; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_permission_menu" VALUES (1, 1, '控制台', '控制台菜单', 'icon-dash_board', 0, '/', NULL, NULL, '控制台菜单', 'common.menu.dash', 1, 1, '2022-11-19 12:47:26.74763');
INSERT INTO "public"."asf_permission_menu" VALUES (2, 2, '控制面板', '控制面板菜单', 'icon-dash_board', 0, '/control', NULL, NULL, '控制面板菜单', 'common.menu.control', 1, 1, '2022-11-19 12:47:26.752622');
INSERT INTO "public"."asf_permission_menu" VALUES (3, 3, '账户管理', '账户管理', 'icon--proxyaccount', 0, '/control/account', NULL, NULL, '账户管理菜单', 'common.menu.account', 1, 1, '2022-11-19 12:47:26.754557');
INSERT INTO "public"."asf_permission_menu" VALUES (4, 4, '权限管理', '权限管理', 'icon-icon-authority', 0, '/control/permission', NULL, NULL, '权限管理菜单', 'common.menu.permission', 1, 1, '2022-11-19 12:47:26.757387');
INSERT INTO "public"."asf_permission_menu" VALUES (5, 5, '菜单管理', '菜单管理', 'icon-caidan', 0, '/control/menu', NULL, NULL, '菜单管理菜单', 'common.menu.menu', 1, 1, '2022-11-19 12:47:26.760331');
INSERT INTO "public"."asf_permission_menu" VALUES (6, 6, '授权api管理', 'api管理', 'icon-api', 0, '/control/authapi', NULL, NULL, '授权api菜单', 'common.menu.api', 1, 1, '2022-11-19 12:47:26.762817');
INSERT INTO "public"."asf_permission_menu" VALUES (7, 7, '角色管理', '角色管理', 'icon-role', 0, '/control/role', NULL, NULL, '角色管理菜单', 'common.menu.role', 1, 1, '2022-11-19 12:47:26.765302');
INSERT INTO "public"."asf_permission_menu" VALUES (8, 8, '审计管理', '审计管理', 'icon-audio', 0, '/audio', NULL, NULL, '审计管理菜单', 'common.menu.audit', 1, 1, '2022-11-19 12:47:26.768516');
INSERT INTO "public"."asf_permission_menu" VALUES (9, 9, '日志管理', '日志管理', 'icon-errorcorrection_default', 0, '/control/audio/getlog', NULL, NULL, '日志管理菜单', 'common.menu.loglist', 1, 1, '2022-11-19 12:47:26.771202');
INSERT INTO "public"."asf_permission_menu" VALUES (11, 11, '租户管理', '租户管理', 'icon-tenancy', 0, '/control/tenancy', NULL, NULL, '租户管理菜单', 'common.menu.tenancy', 1, 1, '2022-11-19 12:47:26.776489');
INSERT INTO "public"."asf_permission_menu" VALUES (12, 12, '部门管理', '部门管理', 'icon-bumen', 0, '/control/department', NULL, NULL, '部门管理菜单', 'common.menu.department', 1, 1, '2022-11-19 12:47:26.780295');
INSERT INTO "public"."asf_permission_menu" VALUES (13, 13, '岗位管理', '岗位管理', 'icon-gangwei', 0, '/control/post', NULL, NULL, '岗位管理菜单', 'common.menu.post', 1, 1, '2022-11-19 12:47:26.782922');
INSERT INTO "public"."asf_permission_menu" VALUES (14, 14, '多语言管理', '多语言管理', 'icon-EA', 0, '/control/translate', NULL, NULL, '多语言管理菜单', 'common.menu.translate', 1, 1, '2022-11-19 12:47:26.785668');
INSERT INTO "public"."asf_permission_menu" VALUES (15, 15, '字典管理', '字典管理', 'icon-EA', 0, '/control/dictionary', NULL, NULL, '多语言管理菜单', 'common.menu.dictionary', 1, 1, '2022-11-19 12:47:26.789662');
INSERT INTO "public"."asf_permission_menu" VALUES (478195315633975296, 478194271101284352, '国家管理', '国家管理', 'icon-dash_board', 0, '/control/country', NULL, NULL, '国家管理', 'common.menu.contry', 1, 1, '2023-11-11 13:37:27.761121');


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

INSERT INTO "public"."asf_role_permission" VALUES (22, 1, 2, '2022-11-19 12:47:26.970098');
INSERT INTO "public"."asf_role_permission" VALUES (23, 4, 2, '2022-11-19 12:47:26.975585');
INSERT INTO "public"."asf_role_permission" VALUES (24, 5, 2, '2022-11-19 12:47:26.979874');
INSERT INTO "public"."asf_role_permission" VALUES (25, 6, 2, '2022-11-19 12:47:26.981616');
INSERT INTO "public"."asf_role_permission" VALUES (26, 8, 2, '2022-11-19 12:47:26.983295');
INSERT INTO "public"."asf_role_permission" VALUES (27, 9, 2, '2022-11-19 12:47:26.985562');
INSERT INTO "public"."asf_role_permission" VALUES (28, 14, 2, '2022-11-19 12:47:26.987631');
INSERT INTO "public"."asf_role_permission" VALUES (29, 15, 2, '2022-11-19 12:47:26.989538');
INSERT INTO "public"."asf_role_permission" VALUES (30, 16, 2, '2022-11-19 12:47:26.992033');
INSERT INTO "public"."asf_role_permission" VALUES (32, 331075142022815744, 2, '2022-11-19 12:47:26.995879');
INSERT INTO "public"."asf_role_permission" VALUES (33, 2, 2, '2022-11-19 12:47:26.972609');
INSERT INTO "public"."asf_role_permission" VALUES (34, 16, 3, '2022-11-19 12:47:26.99912');
INSERT INTO "public"."asf_role_permission" VALUES (36, 331075142022815744, 3, '2022-11-19 12:47:27.00308');
INSERT INTO "public"."asf_role_permission" VALUES (37, 1, 3, '2022-11-19 12:47:26.997474');
INSERT INTO "public"."asf_role_permission" VALUES (170, 1, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (171, 2, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (172, 3, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (173, 4, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (174, 5, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (175, 6, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (176, 7, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (177, 8, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (178, 9, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (179, 10, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (180, 11, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (181, 12, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (182, 13, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (183, 14, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (184, 15, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (185, 16, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (186, 331075142022815744, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (187, 389431849661984768, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (188, 389447011546656768, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (189, 389447780190613504, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (190, 394410371264667648, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (191, 478194271101284352, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (192, 485352284338974720, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (193, 485352564237463552, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (194, 485352864956477440, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (195, 485363648935686144, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (196, 485364164180766720, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (197, 485363950019604480, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (198, 485364447438893056, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (199, 485364645519093760, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (200, 485364858954641408, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (201, 485365171203796992, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (202, 485365440721383424, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (203, 485365912324730880, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (204, 485368073548918784, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (205, 485368188766449664, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (206, 485368357465550848, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (207, 485368484557156352, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (208, 485368776342302720, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (209, 485369312634400768, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (210, 485369079917637632, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (211, 485369995576143872, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (212, 485370273377480704, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (213, 485370518333222912, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (214, 485370677171515392, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (215, 485370971976560640, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (216, 485371141669711872, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (217, 485374635382337536, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (218, 485377691046047744, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (219, 485377839499243520, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (220, 485379729205161984, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (221, 485379905353347072, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (222, 485352694336385024, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (223, 485380090871607296, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (224, 485380826145681408, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (225, 485381004583956480, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (226, 485381179968778240, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (227, 485381332217819136, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (228, 485378624828141568, 1, '2025-03-27 08:56:49.319319');
INSERT INTO "public"."asf_role_permission" VALUES (229, 660039519033339904, 1, '2025-03-27 08:56:49.319319');


--
-- Data for Name: asf_security_token; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_security_token" VALUES (308, 1, 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzQ0NDY3MzU2LCJleHAiOjE3NDQ1NTM3NTYsImlhdCI6MTc0NDQ2NzM1NiwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.tJEA414JvbJPo8sVBEc5x6yDekq--kzHRwd6Z1_M-HN8LplC7pZQARPvjjMZZe1Hr4kEONxNYq5vXngnTwJ-dmqZFbOOR7-GrApNorW-9jGVkswB9R_fFdCajG8Du2J9vswTw3J6NG0gRoJtcJiiukpiaIGGEq9hF0CG0G4eCto7jnmTaaIeNwu2L9LY4aQ_hx2WhmTjq0FPFkWzvIhqjd4nv2dC9oF9joCuJq97IsHI5oySIbpncQdzbQzPlt8PBG-Nof9Mmy2OOzYm2mv0mwwT7ZVW6SO3jo2FaH--QrZwIqiOnQgJS3CmFFShjl1-VNmvrH04Qk9GyRaM9F23Ew', '2025-04-13 14:15:56.146049+00', '2025-08-24 13:38:10.514347');
INSERT INTO "public"."asf_security_token" VALUES (309, 1, 'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtlZXBfd2FuIiwicm9sZSI6WyJzdXBlcmFkbWluIiwidXNlciJdLCJuYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwiYXV0aF9tb2RlIjoiVXNlcm5hbWVBbmRQYXNzd29yZCIsInRlbmFuY3lfaWQiOiIxIiwibmJmIjoxNzQ0NDY3MzU2LCJleHAiOjE3NDQ1OTY5NTYsImlhdCI6MTc0NDQ2NzM1NiwiaXNzIjoiYXNmIiwiYXVkIjoiYXNmIn0.x7i43zJCrc2uMMjtyHMrF1gCvDorjXqNaLQP5D88BLbhna2oPGf6u-sOqVH1QnQ2kYjJ15Vu5uUUmVluYI06UAOw43Va5FzBk7QyxEKx9pziPVkJQr2mHGvqkhIoJM4GOCVQOirF1L3axx_Ed3Cjp24fDWtLFxAZ7tNSG4hoorKjPkCmAVhhDAnglAItpzNF4kOToi2le43aYHr1ebItym7OqXjAaNsiP6bP5UQMhFEvlR0wgJsrtjomoVrF7fiRDYouyM3iqdtLfvWRTxYHYUM575_RGRmuxSOBJnKRRGxX_n0K2BlKKHNya1rER8Y9yKLwHvpNFpK73S4o0ajR3g', '2025-04-13 14:15:56.146049+00', '2025-08-24 13:38:10.548138');


--
-- Data for Name: asf_tenancy; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_tenancy" VALUES (1, '总部集团', 0, 0, 1, 1, 0, '2022-11-19 12:47:26.43899');
INSERT INTO "public"."asf_tenancy" VALUES (2, '公司A', 0, 0, 1, 1, 0, '2022-11-19 12:47:26.446391');


--
-- Data for Name: asf_translate; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO "public"."asf_translate" VALUES (478230414452346880, '登录', 1, 'common.login', 'Login', 'ID', 'admin', '2023-11-11 15:56:55.920214', 1);
INSERT INTO "public"."asf_translate" VALUES (478758892920008704, '记住我', 1, 'common.remember.me', 'remember me', 'ID', 'admin', '2023-11-13 10:56:54.983608', 1);
INSERT INTO "public"."asf_translate" VALUES (478812642569252864, '账号密码登录', 1, 'common.account.password', 'Account Password Login', 'ID', 'admin', '2023-11-13 14:30:29.897939', 1);
INSERT INTO "public"."asf_translate" VALUES (478815079166275584, '邮箱密码登录', 1, 'common.email.password', 'Email Password Login ', 'ID', 'admin', '2023-11-13 14:40:10.828624', 1);
INSERT INTO "public"."asf_translate" VALUES (478819971729616896, '控制台', 1, 'common.menu.dash', 'Dash', 'ID', 'admin', '2023-11-13 14:59:37.305755', 1);
INSERT INTO "public"."asf_translate" VALUES (478907023183736832, '控制面板', 1, 'common.menu.control', 'Control', 'ID', 'admin', '2023-11-13 20:45:31.990456', 1);
INSERT INTO "public"."asf_translate" VALUES (478907647577190400, '账户管理', 1, 'common.menu.account', 'Account Manage', 'ID', 'admin', '2023-11-13 20:48:00.85683', 1);
INSERT INTO "public"."asf_translate" VALUES (478907863088918528, '权限管理', 1, 'common.menu.permission', 'Permission Manage', 'ID', 'admin', '2023-11-13 20:48:52.239182', 1);
INSERT INTO "public"."asf_translate" VALUES (478908032094203904, '菜单管理', 1, 'common.menu.menu', 'Menu Manage', 'ID', 'admin', '2023-11-13 20:49:32.533745', 1);
INSERT INTO "public"."asf_translate" VALUES (478908219411820544, 'API管理', 1, 'common.menu.api', 'Api Manage', 'ID', 'admin', '2023-11-13 20:50:17.192963', 1);
INSERT INTO "public"."asf_translate" VALUES (478908390723973120, '角色管理', 1, 'common.menu.role', 'Role Manage', 'ID', 'admin', '2023-11-13 20:50:58.037002', 1);
INSERT INTO "public"."asf_translate" VALUES (478909578018189312, '审计管理', 1, 'common.menu.audit', 'Audit Manage', 'ID', 'admin', '2023-11-13 20:55:41.110409', 1);
INSERT INTO "public"."asf_translate" VALUES (478909774928179200, '日志列表', 1, 'common.menu.loglist', 'Log List', 'ID', 'admin', '2023-11-13 20:56:28.057006', 1);
INSERT INTO "public"."asf_translate" VALUES (478910033934839808, '租户管理', 1, 'common.menu.tenancy', 'Tenancy Manage', 'ID', 'admin', '2023-11-13 20:57:29.808814', 1);
INSERT INTO "public"."asf_translate" VALUES (478910575608229888, '部门管理', 1, 'common.menu.department', 'Department Mange', 'ID', 'admin', '2023-11-13 20:59:38.954442', 1);
INSERT INTO "public"."asf_translate" VALUES (478910799579869184, '岗位管理', 1, 'common.menu.post', 'Post Manage', 'ID', 'admin', '2023-11-13 21:00:32.353104', 1);
INSERT INTO "public"."asf_translate" VALUES (478911100957388800, '多语言管理', 1, 'common.menu.translate', 'Translate Manage', 'ID', 'admin', '2023-11-13 21:01:44.206857', 1);
INSERT INTO "public"."asf_translate" VALUES (478911386782429184, '字典管理', 1, 'common.menu.dictionary', 'Dictionary Manage', 'ID', 'admin', '2023-11-13 21:02:52.353547', 1);
INSERT INTO "public"."asf_translate" VALUES (478911581465243648, '国家管理', 1, 'common.menu.contry', 'Contry Manage', 'ID', 'admin', '2023-11-13 21:03:38.768778', 1);
INSERT INTO "public"."asf_translate" VALUES (478911840450932736, '个人中心', 1, 'common.user.center', 'User Center', 'ID', 'admin', '2023-11-13 21:04:40.515875', 1);
INSERT INTO "public"."asf_translate" VALUES (478912019421884416, '登出', 1, 'common.logout', 'Logout', 'ID', 'admin', '2023-11-13 21:05:23.186675', 1);
INSERT INTO "public"."asf_translate" VALUES (478912412562386944, '查询', 1, 'common.query', 'Query', 'ID', 'admin', '2023-11-13 21:06:56.918148', 1);
INSERT INTO "public"."asf_translate" VALUES (478913744895635456, '重置', 1, 'common.reset', 'Reset', 'ID', 'admin', '2023-11-13 21:12:14.571042', 1);
INSERT INTO "public"."asf_translate" VALUES (478913922822205440, '添加', 1, 'common.add', 'Add', 'ID', 'admin', '2023-11-13 21:12:56.991749', 1);
INSERT INTO "public"."asf_translate" VALUES (478914089986191360, '编辑', 1, 'common.edit', 'Edit', 'ID', 'admin', '2023-11-13 21:13:36.847462', 1);
INSERT INTO "public"."asf_translate" VALUES (478914254998499328, '操作', 1, 'common.action', 'Action', 'ID', 'admin', '2023-11-13 21:14:16.189512', 1);
INSERT INTO "public"."asf_translate" VALUES (485346201855782912, '手机号码登录', 1, 'common.phone.login', 'Phone Login', 'ID', 'admin', '2023-12-01 07:12:31.827892', 1);
INSERT INTO "public"."asf_translate" VALUES (485348409439612928, '会员管理', 1, 'common.member.manage', 'Member Manage', 'ID', 'admin', '2023-12-01 07:21:18.106352', 1);
INSERT INTO "public"."asf_translate" VALUES (485348760620298240, '会员列表', 1, 'common.member.list', 'Member List', 'ID', 'admin', '2023-12-01 07:22:41.834064', 1);
INSERT INTO "public"."asf_translate" VALUES (485349180184915968, '会员相册', 1, 'common.member.album', 'Member Album', 'ID', 'admin', '2023-12-01 07:24:21.865899', 1);
INSERT INTO "public"."asf_translate" VALUES (485351525048315904, '会员动态', 1, 'common.member.trends', 'Member Trends', 'ID', 'admin', '2023-12-01 07:33:40.915048', 1);
INSERT INTO "public"."asf_translate" VALUES (485648167166943232, '头像审核', 1, 'common.member.avatar', 'Avatar review', 'ID', 'admin', '2023-12-02 03:12:25.963803', 1);
INSERT INTO "public"."asf_translate" VALUES (485648641077157888, '签名审核', 1, 'common.member.sign', 'SIgn review', 'ID', 'admin', '2023-12-02 03:14:18.95379', 1);
INSERT INTO "public"."asf_translate" VALUES (485649006409424896, '昵称审核', 1, 'common.member.nickname', 'Nickname review', 'ID', 'admin', '2023-12-02 03:15:46.056006', 1);
INSERT INTO "public"."asf_translate" VALUES (485649353660047360, '真人认证', 1, 'common.member.real', 'Real person', 'ID', 'admin', '2023-12-02 03:17:08.849627', 1);
INSERT INTO "public"."asf_translate" VALUES (485650101093408768, '会员设备', 1, 'common.member.device', 'Member Device', 'ID', 'admin', '2023-12-02 03:20:07.045676', 1);
INSERT INTO "public"."asf_translate" VALUES (485649798830891008, '会员黑名单', 1, 'common.member.blacklist', 'Member Blacklist', 'ID', 'admin', '2023-12-02 03:18:54.979405', 1);
INSERT INTO "public"."asf_translate" VALUES (485651009948753920, '会员关注', 1, 'common.member.flow', 'Member Flow', 'ID', 'admin', '2023-12-02 03:23:43.739892', 1);
INSERT INTO "public"."asf_translate" VALUES (485651675937120256, '会员礼券', 1, 'common.member.gift', 'Member Gift', 'ID', 'admin', '2023-12-02 03:26:22.525144', 1);
INSERT INTO "public"."asf_translate" VALUES (485652041265192960, '会员礼券记录', 1, 'common.member.gift_record', 'Member Gift Record', 'ID', 'admin', '2023-12-02 03:27:49.628299', 1);
INSERT INTO "public"."asf_translate" VALUES (485652387140083712, '会员支付记录', 1, 'common.member.payment_record', 'Member Payment Record', 'ID', 'admin', '2023-12-02 03:29:12.090637', 1);
INSERT INTO "public"."asf_translate" VALUES (485652719098273792, '会员消费记录', 1, 'common.member.purchase_history', 'Member Purchase Record', 'ID', 'admin', '2023-12-02 03:30:31.236873', 1);
INSERT INTO "public"."asf_translate" VALUES (485652983821770752, '会员设置', 1, 'common.member.setting', 'Member Setting', 'ID', 'admin', '2023-12-02 03:31:34.353238', 1);
INSERT INTO "public"."asf_translate" VALUES (485653301175394304, '会员社交账号', 1, 'common.member.socialize', 'Member Socialize', 'ID', 'admin', '2023-12-02 03:32:50.017093', 1);
INSERT INTO "public"."asf_translate" VALUES (485653568298033152, '会员提现记录', 1, 'common.member.withdrawal_record', 'Member Withdrawal Record', 'ID', 'admin', '2023-12-02 03:33:53.704301', 1);
INSERT INTO "public"."asf_translate" VALUES (485662898963488768, '社交设置', 1, 'common.setting', 'Setting', 'ID', 'admin', '2023-12-02 04:10:58.449138', 1);
INSERT INTO "public"."asf_translate" VALUES (485663304410079232, '活动设置', 1, 'common.setting.active', 'Active Setting', 'ID', 'admin', '2023-12-02 04:12:35.11491', 1);
INSERT INTO "public"."asf_translate" VALUES (485663618462785536, 'app设置', 1, 'common.setting.app', 'App Setting', 'ID', 'admin', '2023-12-02 04:13:49.993067', 1);
INSERT INTO "public"."asf_translate" VALUES (485663940547584000, 'banner设置', 1, 'common.setting.banner', 'Banner Setting', 'ID', 'admin', '2023-12-02 04:15:06.786081', 1);
INSERT INTO "public"."asf_translate" VALUES (485664178238791680, '招呼语句设置', 1, 'common.setting.call', 'Call Setting', 'ID', 'admin', '2023-12-02 04:16:03.458802', 1);
INSERT INTO "public"."asf_translate" VALUES (485665446231416832, '收费设置', 1, 'common.setting.charge', 'Charge Setting', 'ID', 'admin', '2023-12-02 04:21:05.778869', 1);
INSERT INTO "public"."asf_translate" VALUES (485665683964567552, '颜色设置', 1, 'common.setting.color', 'Color Setting', 'ID', 'admin', '2023-12-02 04:22:02.461584', 1);
INSERT INTO "public"."asf_translate" VALUES (485666224392249344, '货币分成设置', 1, 'common.setting.currency', 'Currency Setting', 'ID', 'admin', '2023-12-02 04:24:11.30537', 1);
INSERT INTO "public"."asf_translate" VALUES (485666592673112064, '货币兑换', 1, 'common.setting.exchange', 'Exchange Setting', 'ID', 'admin', '2023-12-02 04:25:39.110038', 1);
INSERT INTO "public"."asf_translate" VALUES (485666945829314560, '礼物价格', 1, 'common.setting.gift_price', 'Gift Price', 'ID', 'admin', '2023-12-02 04:27:03.312138', 1);
INSERT INTO "public"."asf_translate" VALUES (485667314709962752, '帮助设置', 1, 'common.setting.help', 'Help Setting', 'ID', 'admin', '2023-12-02 04:28:31.262082', 1);
INSERT INTO "public"."asf_translate" VALUES (485668327290445824, '导航设置', 1, 'common.setting.nav', 'Nav Setting', 'ID', 'admin', '2023-12-02 04:32:32.682354', 1);
INSERT INTO "public"."asf_translate" VALUES (485668575568076800, '其他设置', 1, 'common.setting.other', 'Other Setting', 'ID', 'admin', '2023-12-02 04:33:31.878088', 1);
INSERT INTO "public"."asf_translate" VALUES (478227885082738688, '登录', 1, 'common.login', '登录', 'CN', 'admin', '2023-11-11 15:46:52.89787', 1);
INSERT INTO "public"."asf_translate" VALUES (478758791845670912, '记住我', 1, 'common.remember.me', '记住我', 'CN', 'admin', '2023-11-13 10:56:30.890305', 1);
INSERT INTO "public"."asf_translate" VALUES (478806644026667008, '账号密码登录', 1, 'common.account.password', '账号密码登录', 'CN', 'admin', '2023-11-13 14:06:39.735037', 1);
INSERT INTO "public"."asf_translate" VALUES (478814983611641856, '邮箱密码登录', 1, 'common.email.password', '邮箱密码登录', 'CN', 'admin', '2023-11-13 14:39:48.046109', 1);
INSERT INTO "public"."asf_translate" VALUES (478819889311543296, '控制台', 1, 'common.menu.dash', '控制台', 'CN', 'admin', '2023-11-13 14:59:17.656256', 1);
INSERT INTO "public"."asf_translate" VALUES (478906863099736064, '控制面板', 1, 'common.menu.control', '控制面板', 'CN', 'admin', '2023-11-13 20:44:53.823408', 1);
INSERT INTO "public"."asf_translate" VALUES (478907365740933120, '账户管理', 1, 'common.menu.account', '账户管理', 'CN', 'admin', '2023-11-13 20:46:53.662615', 1);
INSERT INTO "public"."asf_translate" VALUES (478907746860560384, '权限管理', 1, 'common.menu.permission', '权限管理', 'CN', 'admin', '2023-11-13 20:48:24.527637', 1);
INSERT INTO "public"."asf_translate" VALUES (478907963215343616, '菜单管理', 1, 'common.menu.menu', '菜单管理', 'CN', 'admin', '2023-11-13 20:49:16.110989', 1);
INSERT INTO "public"."asf_translate" VALUES (478908145923420160, 'API管理', 1, 'common.menu.api', 'API管理', 'CN', 'admin', '2023-11-13 20:49:59.672399', 1);
INSERT INTO "public"."asf_translate" VALUES (478908303381786624, '角色管理', 1, 'common.menu.role', '角色管理', 'CN', 'admin', '2023-11-13 20:50:37.213507', 1);
INSERT INTO "public"."asf_translate" VALUES (478909489711312896, '审计管理', 1, 'common.menu.audit', '审计管理', 'CN', 'admin', '2023-11-13 20:55:20.05666', 1);
INSERT INTO "public"."asf_translate" VALUES (478909698247913472, '日志列表', 1, 'common.menu.loglist', '日志列表', 'CN', 'admin', '2023-11-13 20:56:09.775117', 1);
INSERT INTO "public"."asf_translate" VALUES (478909940246671360, '租户管理', 1, 'common.menu.tenancy', '租户管理', 'CN', 'admin', '2023-11-13 20:57:07.472548', 1);
INSERT INTO "public"."asf_translate" VALUES (478910437229752320, '部门管理', 1, 'common.menu.department', '部门管理', 'CN', 'admin', '2023-11-13 20:59:05.962198', 1);
INSERT INTO "public"."asf_translate" VALUES (478910683066298368, '岗位管理', 1, 'common.menu.post', '岗位管理', 'CN', 'admin', '2023-11-13 21:00:04.57405', 1);
INSERT INTO "public"."asf_translate" VALUES (478910934451908608, '多语言姑那里', 1, 'common.menu.translate', '多语言管理', 'CN', 'admin', '2023-11-13 21:01:04.509412', 1);
INSERT INTO "public"."asf_translate" VALUES (478911258147319808, '字典管理', 1, 'common.menu.dictionary', '字典管理', 'CN', 'admin', '2023-11-13 21:02:21.684386', 1);
INSERT INTO "public"."asf_translate" VALUES (478911493011566592, '国家管理', 1, 'common.menu.contry', '国家管理', 'CN', 'admin', '2023-11-13 21:03:17.680203', 1);
INSERT INTO "public"."asf_translate" VALUES (478911750776713216, '个人中心', 1, 'common.user.center', '个人中心', 'CN', 'admin', '2023-11-13 21:04:19.135725', 1);
INSERT INTO "public"."asf_translate" VALUES (478911945157537792, '登出', 1, 'common.logout', '登出', 'CN', 'admin', '2023-11-13 21:05:05.479894', 1);
INSERT INTO "public"."asf_translate" VALUES (478912325979369472, '查询', 1, 'common.query', '查询', 'CN', 'admin', '2023-11-13 21:06:36.275207', 1);
INSERT INTO "public"."asf_translate" VALUES (478913658304229376, '重置', 1, 'common.reset', '重置', 'CN', 'admin', '2023-11-13 21:11:53.925778', 1);
INSERT INTO "public"."asf_translate" VALUES (478913853930762240, '添加', 1, 'common.add', '添加', 'CN', 'admin', '2023-11-13 21:12:40.567003', 1);
INSERT INTO "public"."asf_translate" VALUES (478914024651517952, '编辑', 1, 'common.edit', '编辑', 'CN', 'admin', '2023-11-13 21:13:21.270044', 1);
INSERT INTO "public"."asf_translate" VALUES (478914182059552768, '操作', 1, 'common.action', '操作', 'CN', 'admin', '2023-11-13 21:13:58.799399', 1);
INSERT INTO "public"."asf_translate" VALUES (485346010603909120, '手机号码登录', 1, 'common.phone.login', '手机号码登录', 'CN', 'admin', '2023-12-01 07:11:46.416365', 1);


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
-- Name: asf_app_setting_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_app_setting_id_seq"', 1, false);


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
-- Name: asf_help_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_help_id_seq"', 1, false);


--
-- Name: asf_loginfos_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_loginfos_id_seq"', 1, false);


--
-- Name: asf_loginfos_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_loginfos_id_seq1"', 1, false);


--
-- Name: asf_message_inbox_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_message_inbox_id_seq"', 1, false);


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

SELECT pg_catalog.setval('"public"."asf_role_permission_id_seq1"', 229, true);


--
-- Name: asf_security_token_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_security_token_id_seq"', 1, true);


--
-- Name: asf_security_token_id_seq1; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('"public"."asf_security_token_id_seq1"', 309, true);


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
-- Name: asf_app_setting asf_app_setting_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_app_setting"
    ADD CONSTRAINT "asf_app_setting_pkey" PRIMARY KEY ("id");


--
-- Name: asf_country asf_country_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_country"
    ADD CONSTRAINT "asf_country_pkey" PRIMARY KEY ("id");


--
-- Name: asf_help asf_help_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_help"
    ADD CONSTRAINT "asf_help_pkey" PRIMARY KEY ("id");


--
-- Name: asf_message_inbox asf_message_inbox_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY "public"."asf_message_inbox"
    ADD CONSTRAINT "asf_message_inbox_pkey" PRIMARY KEY ("id");


--
-- Name: IX_appsetting_wrap_name; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_appsetting_wrap_name" ON "public"."asf_app_setting" USING "btree" ("wrap_name", "version_no ");


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
-- Name: IX_country_code; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_country_code" ON "public"."asf_country" USING "btree" ("language_code");


--
-- Name: IX_country_name; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_country_name" ON "public"."asf_country" USING "btree" ("name");


--
-- Name: IX_help_category; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_help_category" ON "public"."asf_help" USING "btree" ("category");


--
-- Name: INDEX "IX_help_category"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON INDEX "public"."IX_help_category" IS '分类索引';


--
-- Name: IX_help_title; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_help_title" ON "public"."asf_help" USING "btree" ("title");


--
-- Name: IX_message_title; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_message_title" ON "public"."asf_message_inbox" USING "btree" ("title");


--
-- Name: INDEX "IX_message_title"; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON INDEX "public"."IX_message_title" IS '站内信标题';


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

