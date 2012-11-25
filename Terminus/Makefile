
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/Terminus.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../libRegex/bin/Debug/libRegex.dll \
	../libTerminus/bin/Debug/libTerminus.dll
BUILD_DIR = bin/Debug

TERMINUS_EXE_MDB_SOURCE=bin/Debug/Terminus.exe.mdb
TERMINUS_EXE_MDB=$(BUILD_DIR)/Terminus.exe.mdb
LIBREGEX_DLL_SOURCE=../libRegex/bin/Debug/libRegex.dll
LIBREGEX_DLL_MDB_SOURCE=../libRegex/bin/Debug/libRegex.dll.mdb
LIBTERMINUS_DLL_SOURCE=../libTerminus/bin/Debug/libTerminus.dll
LIBTERMINUS_DLL_MDB_SOURCE=../libTerminus/bin/Debug/libTerminus.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Terminus.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../libRegex/bin/Release/libRegex.dll \
	../libTerminus/bin/Release/libTerminus.dll
BUILD_DIR = bin/Release

TERMINUS_EXE_MDB=
LIBREGEX_DLL_SOURCE=../libRegex/bin/Debug/libRegex.dll
LIBREGEX_DLL_MDB_SOURCE=../libRegex/bin/Debug/libRegex.dll.mdb
LIBTERMINUS_DLL_SOURCE=../libTerminus/bin/Debug/libTerminus.dll
LIBTERMINUS_DLL_MDB_SOURCE=../libTerminus/bin/Debug/libTerminus.dll.mdb

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TERMINUS_EXE_MDB) \
	$(LIBREGEX_DLL) \
	$(LIBREGEX_DLL_MDB) \
	$(LIBTERMINUS_DLL) \
	$(LIBTERMINUS_DLL_MDB)  

BINARIES = \
	$(TERMINUS)  


RESGEN=resgen2

LIBREGEX_DLL = $(BUILD_DIR)/libRegex.dll
LIBREGEX_DLL_MDB = $(BUILD_DIR)/libRegex.dll.mdb
LIBTERMINUS_DLL = $(BUILD_DIR)/libTerminus.dll
LIBTERMINUS_DLL_MDB = $(BUILD_DIR)/libTerminus.dll.mdb
TERMINUS = $(BUILD_DIR)/terminus

FILES =  \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	gtk-gui/MainWindow.cs \
	Main.cs \
	MainWindow.cs 

DATA_FILES = 

RESOURCES =  \
	bin/Debug/Boot/Images/Programm.png,Terminus.bin.Debug.Boot.Images.Programm.png \
	gtk-gui/gui.stetic 

EXTRAS = \
	terminus.in 

REFERENCES =  \
	../libRegex/bin/Debug/libRegex.dll \
	../libTerminus/bin/Debug/libTerminus.dll \
	Mono.Posix \
	-pkg:glade-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:gtk-sharp-2.0 \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,LIBREGEX_DLL))
$(eval $(call emit-deploy-target,LIBREGEX_DLL_MDB))
$(eval $(call emit-deploy-target,LIBTERMINUS_DLL))
$(eval $(call emit-deploy-target,LIBTERMINUS_DLL_MDB))
$(eval $(call emit-deploy-wrapper,TERMINUS,terminus,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TERMINUS_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIBREGEX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIBREGEX_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIBTERMINUS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIBTERMINUS_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(TERMINUS),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TERMINUS_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIBREGEX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIBREGEX_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIBTERMINUS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIBTERMINUS_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TERMINUS),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
